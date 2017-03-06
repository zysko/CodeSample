using GitHubApi.Data;
using GitHubApi.Helpers;
using GitHubApi.Infrastructure;
using System;

namespace GitHubApi.Example
{
	public class Program
	{
		public static void Main(string[] args)
		{
			OnlineDataAccessExample();
			OfflineDataAccessExample();
			Console.ReadLine();
		}

		private static void OnlineDataAccessExample()
		{
			Console.WriteLine("----------ONLINE----------");
			var service = new Service(new OnlineDataAccess());
			DoExample(service);
		}

		private static void OfflineDataAccessExample()
		{
			Console.WriteLine("----------OFFLINE----------");
			var service = new Service(new OfflineDataAccess());
			DoExample(service);
		}

		private static void DoExample(IService service)
		{
			LinkedDataList<User> usersList = service.GetLinkedDataList<User, GitUser>(new Link(UriHelper.UsersUri));
			foreach (var userItem in usersList.DataList)
			{
				Console.WriteLine("User Id: {0}, User Login: {1}", userItem.Id, userItem.Login);
			}

			var firstUser = usersList[0];
			Console.WriteLine("User {0} has {1} repositories:", firstUser.Login, firstUser.RepositoryCount);

			var userRepositories = service.GetLinkedDataList<Repository, GitRepository>(new Link(string.Format(UriHelper.UserRepositoryUserFormat, firstUser.Id)));

			foreach (var repo in userRepositories.DataList)
			{
				Console.WriteLine("Repo name: {0}, Description: {1}", repo.Name, repo.Description);
			}

			var firstRepo = userRepositories[0];
			Console.WriteLine("Repository: {0} has {1} subscribers.", firstRepo.Name, firstRepo.SubscribersCount);
		}

	}
}
