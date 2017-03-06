using GitHubApi.Exceptions;
using GitHubApi.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Infrastructure
{
	public class OnlineDataAccess : IDataAccess
	{
		HttpClient _httpClient;

		public OnlineDataAccess()
		{
			_httpClient = new HttpClient(new HttpClientHandler() { AllowAutoRedirect = true });
		}

		public bool IsOnline
		{
			get
			{
				return true;
			}
		}

		public IResponse SendRequest(IRequest request)
		{
			var response = SendRequestAsync(request);
			response.Wait();
			return response.Result;
		}

		private async Task<IResponse> SendRequestAsync(IRequest request)
		{
			var httpRequest = PrepareHttpRequest(request);
			using (httpRequest)
			{
				var response = await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);
				return await PrepareResponse(response).ConfigureAwait(false);
			}
		}

		private async Task<IResponse> PrepareResponse(HttpResponseMessage httpResponse)
		{
			string body = null;

			if (httpResponse.Content != null)
			{
				using (var content = httpResponse.Content)
				{
					body = await content.ReadAsStringAsync().ConfigureAwait(false);
				}
			}
			var response = new Response(body, GetLinkFromHeaders(httpResponse.Headers));
			if (!httpResponse.IsSuccessStatusCode)
				throw new ApiException(httpResponse.StatusCode, body);
			SaveResponseInCache(response, httpResponse.RequestMessage.RequestUri);
			return response;
		}

		private HttpRequestMessage PrepareHttpRequest(IRequest request)
		{
			HttpRequestMessage httpRequest = new HttpRequestMessage();
			httpRequest.Method = request.Method;
			httpRequest.RequestUri = request.RequestUri;

			foreach (var header in request.Headers)
			{
				httpRequest.Headers.Add(header.Key, header.Value);
			}

			return httpRequest;
		}

		private string GetLinkFromHeaders(HttpResponseHeaders headers)
		{
			string result = null;
			IEnumerable<string> linkValue;
			if (headers.TryGetValues("Link", out linkValue))
			{
				result = linkValue.First();
			}
			return result;
		}

		private void SaveResponseInCache(IResponse response, Uri requestUri)
		{
			var path = UriHelper.GetOfflinePathFromUri(requestUri, "json");
			var directoryPath = path.Substring(0, path.LastIndexOf('\\'));
			Directory.CreateDirectory(directoryPath);
			File.WriteAllText(path, JsonConvert.SerializeObject(response));
		}

	}
}
