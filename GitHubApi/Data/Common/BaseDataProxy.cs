using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
	public abstract class BaseDataProxy<TGitData>
	{
		protected IService service;
		protected TGitData data;

		public BaseDataProxy() { }

		public void Configure(TGitData data, IService dataService)
		{
			service = dataService;
			this.data = data;
		}

		protected void UpdateGitData(string url)
		{
			data = service.GetGitDataWithAdditionalInfo<TGitData>(url);
		}
	}
}
