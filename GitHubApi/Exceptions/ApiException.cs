using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GitHubApi.Exceptions
{
	public class ApiException : Exception
	{
		public HttpStatusCode StatusCode { get; set; }
		public string Body { get; set; }
		public string BodyMessage { get; set; }

		public ApiException(HttpStatusCode statusCode, string body)
			: base("Błąd podczas pobierania odpowiedzi z GitHub API")
		{
			StatusCode = statusCode;
			Body = body;
			if (!string.IsNullOrEmpty(body))
			{
				BodyMessage = ClearMessage(body);
			}
		}

		public string ClearMessage(string body)
		{
			Regex rgx = new Regex("[^a-zA-Z0-9,._/ -]");
			return rgx.Replace(body, "_");
		}
	}
}
