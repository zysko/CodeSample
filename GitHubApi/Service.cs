using GitHubApi.Data;
using GitHubApi.Helpers;
using GitHubApi.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace GitHubApi
{
	public class Service : IService
	{
		private IDataAccess dataAccess;

		public Service(IDataAccess dataAccessObj)
		{
			dataAccess = dataAccessObj;
		}

		public bool IsOnline
		{
			get
			{
				return dataAccess.IsOnline;
			}
		}

		public TGitData GetGitDataWithAdditionalInfo<TGitData>(string url)
		{
			var request = new Request
			{
				RequestUri = new Uri(url),
				Method = HttpMethod.Get
			};

			var response = dataAccess.SendRequest(request);
			return JsonConvert.DeserializeObject<TGitData>(response.Body);
		}

		public LinkedDataList<TData> GetLinkedDataList<TData, TGitData>(Link link)
			where TData : BaseDataProxy<TGitData>, new()
		{
			var request = new Request
			{
				RequestUri = new Uri(link.Url),
				Method = HttpMethod.Get
			};

			var response = dataAccess.SendRequest(request);
			List<TGitData> gitDataList = JsonConvert.DeserializeObject<List<TGitData>>(response.Body);

			var proxyFactory = new DataProxyFactory<TGitData>();
			var repositoryList = gitDataList.Select(x => proxyFactory.CreateProxy<TData>(x, this)).ToList();

			return new LinkedDataList<TData>(repositoryList, Link.ParseLinkHeaderValue(response.LinkHeader));
		}
	}
}
