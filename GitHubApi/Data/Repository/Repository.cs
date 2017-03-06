using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
	public class Repository : BaseDataProxy<GitRepository>
	{
		public Repository() { }

		public long Id
		{
			get
			{
				return data.id;
			}
		}

		public string Name
		{
			get
			{
				return data.name;
			}
		}

		public string FullName
		{
			get
			{
				return data.full_name;
			}
		}

		public bool IsPrivate
		{
			get
			{
				return data.@private;
			}
		}

		public string Url
		{
			get
			{
				return data.url;
			}
		}

		public string Description
		{
			get
			{
				return data.description;
			}
		}

		public int SubscribersCount
		{
			get
			{
				if (!data.subscribers_count.HasValue)
				{
					UpdateGitData(Url);
				}
				return data.subscribers_count.Value;
			}
		}
	}
}
