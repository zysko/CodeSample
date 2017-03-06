using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Helpers
{
	public class Link
	{
		public LinkTypeEnum LinkType { get; private set; }
		public string Url { get; private set; }

		public Link(string url, string type = null)
		{
			LinkType = GetLinkType(type);
			Url = url;
		}

		public static LinkTypeEnum GetLinkType(string type)
		{
			LinkTypeEnum result;
			switch (type)
			{
				case "next":
					result = LinkTypeEnum.Next;
					break;
				case "first":
					result = LinkTypeEnum.First;
					break;
				case "prev":
					result = LinkTypeEnum.Previous;
					break;
				case "last":
					result = LinkTypeEnum.Last;
					break;
				default:
					result = LinkTypeEnum.None;
					break;
			}
			return result;
		}

		public static List<Link> ParseLinkHeaderValue(string linkHeaderValue)
		{
			var result = new List<Link>();
			if (!string.IsNullOrWhiteSpace(linkHeaderValue))
			{
				var linkCandidates = linkHeaderValue.Split(',');
				foreach (var candidate in linkCandidates)
				{
					string type = null;
					string url = null;
					var values = candidate.Split(';');
					foreach (var value in values)
					{
						var val = value.Trim();
						if (val.StartsWith("<") && val.EndsWith(">"))
							url = val.Trim('<', '>');
						else if (val.StartsWith("rel="))
						{
							type = val.Substring("rel=".Length).Trim('"');
						}
					}
					if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(url))
						result.Add(new Link(url, type));
				}
			}
			return result;
		}
	}
}
