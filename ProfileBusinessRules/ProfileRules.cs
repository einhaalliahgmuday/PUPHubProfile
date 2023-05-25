using System;
using DataLayer;

namespace ProfileBusinessRules;

public class ProfileRules
{
	InMemoryProfileData profileData = new InMemoryProfileData();
	
	public List<ProfileAccount> GetAllProfileAccounts()
	{
			return profileData.GetProfileAccounts();
	}
	
	public ProfileAccount GetProfileAccountByUsername(string username)
	{
		var allProfileAccounts = GetAllProfileAccounts();
		ProfileAccount foundAccount = new ProfileAccount();
		
		foreach (var account in allProfileAccounts)
		{
			if (username == account.username)
			{
				foundAccount = account;
			}
		}
		
		return foundAccount;
	}
	
	public void DisplayProfile(string username)
	{
		ProfileAccount account = GetProfileAccountByUsername(username);

		Console.WriteLine("{0}	{1}", account.name, account.genderPronouns);
		Console.WriteLine(account.username);
		Console.WriteLine(account.rating);

		Console.WriteLine();

		Console.WriteLine(account.bio);

		Console.WriteLine();
				
		Console.WriteLine("{0} Following	 {1} Followers", account.follows.following.Count, account.follows.followers.Count);
				
		Console.WriteLine();

		Console.WriteLine("About: ");
		Console.WriteLine("Student of {0}", account.courYrSec);
		Console.WriteLine("Lives in {0}", account.location);

		Console.WriteLine();
		Console.WriteLine();
	}
	
	public void EditProfileInformation(string information, string username)
	{
		var allProfileAccounts = GetAllProfileAccounts();
		
		foreach (var account in allProfileAccounts)
		{
			if (username == account.username)
			{
				if (information == "Gender Pronouns")
				{
					Console.Write("Enter updated {0}: ", information);
					account.genderPronouns = Console.ReadLine();
				}
				else if (information == "Bio")
				{
					Console.Write("Enter updated {0}: ", information);
					account.bio = Console.ReadLine();
				}
			}
		}
	}
	
	public void DisplayFollowingList(string username)
	{
		ProfileAccount account = GetProfileAccountByUsername(username);

		Console.WriteLine("FOLLOWING: ");
		
		foreach (var follows in account.follows.following)
		{
			Console.WriteLine("{0}   	{1}", follows.name, follows.username);
		}
		
		Console.WriteLine();
		Console.WriteLine();
	}
	
	public void DisplayFollowersList(string username)
	{
		ProfileAccount account = GetProfileAccountByUsername(username);

		Console.WriteLine("FOLLOWERS: ");
		
		foreach (var follows in account.follows.followers)
		{
			Console.WriteLine("{0}   		{1}", follows.name, follows.username);
		}
		
		Console.WriteLine();
		Console.WriteLine();
	}
	
	public void GenerateProfileLink(string username)
	{
		ProfileAccount account = GetProfileAccountByUsername(username);
		
		Console.WriteLine("Your profile link: https://www.puphub.com/{0}", account.username);
	}

}
