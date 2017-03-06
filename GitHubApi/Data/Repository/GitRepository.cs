﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
	public class GitRepository
	{
		public long id { get; set; }
		public string name { get; set; }
		public string full_name { get; set; }
		public bool @private { get; set; }
		public string url { get; set; }
		public string description { get; set; }
		public int? subscribers_count { get; set; }
	}
}
