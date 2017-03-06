using GitHubApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
	public class LinkedDataList<T>
		where T: class
	{
		public List<T> DataList { get; private set; }
		public List<Link> LinkList { get; private set; }

		public LinkedDataList(List<T> dataList, List<Link> linkList)
		{
			DataList = dataList;
			LinkList = linkList;
		}

		public T this[int index]
		{
			get
			{
				return DataList[index];
			}
		}
	}
}
