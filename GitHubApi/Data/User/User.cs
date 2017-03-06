using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
	public class User : BaseDataProxy<GitUser>
	{
		public User() { }

		public long Id
		{
			get
			{
				return data.id;
			}
		}

		public string Login
		{
			get
			{
				return data.login;
			}
		}

		public string Url
		{
			get
			{
				return data.url;
			}
		}

		public bool IsAdmin
		{
			get
			{
				return data.site_admin;
			}
		}

		public string AvatarUrl
		{
			get
			{
				return data.avatar_url;
			}
		}

		public int RepositoryCount
		{
			get
			{
				if (!data.public_repos.HasValue)
				{
					UpdateGitData(Url);
				}
				return data.public_repos.Value;
			}
		}

	}
}
