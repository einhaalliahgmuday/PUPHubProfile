using System;
using DataLayer;

namespace ProfileBusinessRules;

public class ProfileRules
{
	public List<ProfileAccount> GetAllProfileAccounts()
	{
			InMemoryProfileData profileData = new InMemoryProfileData();
			
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
		
		// int index = GetProfileAccountIndex(username);
		// InMemoryProfileData profileDataa = new InMemoryProfileData();
		
		// Console.WriteLine(profileDataa.profileAccounts[index].genderPronouns);
		
		Console.WriteLine("{0}	{1}", account.name, account.genderPronouns);
		Console.WriteLine(account.username);
		Console.WriteLine(account.rating);

		Console.WriteLine();

		Console.WriteLine(account.bio);

		Console.WriteLine();
				
		Console.WriteLine(" Following	 Followers");
				
		Console.WriteLine();

		Console.WriteLine("About: ");
		Console.WriteLine("Student of {0}", account.courYrSec);
		Console.WriteLine("Lives in {0}", account.location);

		Console.WriteLine();
		Console.WriteLine();
	}
	
	// public void EditProfileInformation(string information, string username)
	// {
		// var allProfileAccounts = GetAllProfileAccounts();
		
		// foreach (var account in allProfileAccounts)
		// {
			// if (username == account.username)
			// {
				// if (information == "Gender Pronouns")
				// {
					// Console.Write("Enter updated {0}: ", information);
					// account.username = Console.ReadLine();
				// }
				// else if (information == "Bio")
				// {
					// Console.Write("Enter updated {0}: ", information);
					// account.bio = Console.ReadLine();
				// }
			// }
		// }
	// }
	
	public int GetProfileAccountIndex(string username)
	{
		var allProfileAccounts = GetAllProfileAccounts();
		int index = 0;
		
		foreach (var account in allProfileAccounts)
		{
			if (username == account.username)
			{
				break;
			}
			index++;
		}
		
		return index;
	}

	public void EditProfileInformation(string information, string username)
	{
		int index = GetProfileAccountIndex(username);
		InMemoryProfileData profileData = new InMemoryProfileData();
		
		// Console.WriteLine(index);
		
		if (information == "Gender Pronouns")
		{
			Console.Write("Enter updated {0}: ", information);
			profileData.profileAccounts[index].genderPronouns = Console.ReadLine();
		}
		
		// Console.WriteLine(profileDataa.profileAccounts[index].genderPronouns);
	}
	
	public void DisplayFollowingList(string username)
	{
		ProfileAccount account = GetProfileAccountByUsername(username);
		
		Console.WriteLine("FOLLOWING: ");
		
		foreach (var follows in account.following)
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
		
		foreach (var follows in account.followers)
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
