using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Helpers
{
	public class UriHelper
	{
		/// <summary>
		/// Base GitHub API address
		/// </summary>
		public const string BaseUri = "https://api.github.com";

		/// <summary>
		/// Get users endpoint (first page, page size = 5)
		/// </summary>
		public const string UsersUri = BaseUri + "/users?per_page=5";

		/// <summary>
		/// Get repositories for user endpoint (first page, default page size)
		/// </summary>
		public const string UserRepositoryUserFormat = BaseUri + "/user/{0}/repos?page=1";

		public static string GetOfflinePathFromUri(Uri uri, string fileExtension)
		{
			var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
			var uriPath = uri.PathAndQuery ?? string.Empty;
			var fileName = "none";
			var dictionaryPath = uriPath;

			if (uriPath.Contains("?"))
			{
				var questionMarkIndex = uriPath.IndexOf('?');
				if (uriPath.Length > questionMarkIndex + 1)
					fileName = uriPath.Substring(questionMarkIndex + 1);
				dictionaryPath = dictionaryPath.Substring(0, questionMarkIndex);
			}

			return string.Format("{0}{1}\\{2}.{3}", appDirectory, dictionaryPath.Replace('/', '\\'), fileName, fileExtension);
		}
	}
}
