using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Exceptions
{
	public class NotCachedException : Exception
	{
		public NotCachedException() :
			base("Dane niedostępne offline.")
		{
		}
	}
}
