using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Infrastructure
{
	public interface IResponse
	{
		string Body { get; }
		string LinkHeader { get; }
	}
}
