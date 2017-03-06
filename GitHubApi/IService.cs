using GitHubApi.Data;
using GitHubApi.Helpers;
using GitHubApi.Infrastructure;

namespace GitHubApi
{
	public interface IService
	{
		bool IsOnline { get; }

		TGitData GetGitDataWithAdditionalInfo<TGitData>(string url);
		LinkedDataList<TData> GetLinkedDataList<TData, TGitData>(Link link) 
			where TData : BaseDataProxy<TGitData>, new();
	}
}
