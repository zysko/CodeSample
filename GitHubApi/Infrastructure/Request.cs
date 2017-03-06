using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Infrastructure
{
	public class Request : IRequest
	{
		public Request()
		{
			Headers = new Dictionary<string, string>();
			Headers.Add("User-Agent", "GitKit.GitHubApi V.1.0");
			Headers.Add("Accept", "application/json");
		}

		public Dictionary<string, string> Headers { get; private set; }
		public HttpMethod Method { get; set; }
		public Uri RequestUri { get; set; }
	}
}
