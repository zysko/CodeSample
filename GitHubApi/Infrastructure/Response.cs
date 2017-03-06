using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Infrastructure
{
	public class Response : IResponse
	{
		public string Body { get; private set; }
		public string LinkHeader { get; private set; }
		public Response(string body, string linkHeader)
		{
			Body = body;
			LinkHeader = linkHeader;
		}
	}
}
