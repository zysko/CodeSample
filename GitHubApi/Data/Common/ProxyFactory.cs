using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
	public class ProxyFactory
	{
		IService service;

		public ProxyFactory(IService dataService)
		{
			service = dataService;
		}

		public TData CreateProxy<TData, TGitData>(TGitData gitData)
			where TData : BaseDataProxy<TGitData>, new()
		{
			var result = new TData();
			result.Configure(gitData, service);
			return result;
		}
	}
}
