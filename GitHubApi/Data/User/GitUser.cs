using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
	public class GitUser
	{
		public string login { get; set; }
		public long id { get; set; }
		public string avatar_url { get; set; }
		public string url { get; set; }
		public string repos_url { get; set; }
		public string type { get; set; }
		public bool site_admin { get; set; }
		public int? public_repos { get; set; }
	}
}
