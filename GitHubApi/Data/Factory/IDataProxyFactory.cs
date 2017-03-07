using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
	public interface IDataProxyFactory<TGitData>
	{
		TData CreateProxy<TData>(TGitData data, IService service)
			where TData : BaseDataProxy<TGitData>, new();
	}
}
