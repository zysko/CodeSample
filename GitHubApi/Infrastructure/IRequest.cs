using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Infrastructure
{
	public interface IRequest
	{
		Dictionary<string, string> Headers { get; }
		HttpMethod Method { get; set; }
		Uri RequestUri { get; set; }
	}
}