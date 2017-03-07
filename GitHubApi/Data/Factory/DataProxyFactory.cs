using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
	public class DataProxyFactory<TGitData> : IDataProxyFactory<TGitData>
	{
		public TData CreateProxy<TData>(TGitData data, IService service)
			where TData: BaseDataProxy<TGitData>, new()
		{
			var result = new TData();
			result.Configure(data, service);
			return result;
		}
	}
}
