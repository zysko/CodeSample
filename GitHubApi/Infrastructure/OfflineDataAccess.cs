using GitHubApi.Exceptions;
using GitHubApi.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Infrastructure
{
	public class OfflineDataAccess : IDataAccess
	{
		public bool IsOnline
		{
			get
			{
				return false;
			}
		}

		public IResponse SendRequest(IRequest request)
		{
			var path = UriHelper.GetOfflinePathFromUri(request.RequestUri, "json");
			string body = string.Empty;
			if (File.Exists(path))
			{
				body = File.ReadAllText(path);
			}

			if (string.IsNullOrEmpty(body))
				throw new NotCachedException();

			return JsonConvert.DeserializeObject<Response>(body);
		}


	}
}
