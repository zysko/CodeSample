using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Infrastructure
{
	public interface IDataAccess
	{
		bool IsOnline { get; }
		IResponse SendRequest(IRequest request);
	}
}
