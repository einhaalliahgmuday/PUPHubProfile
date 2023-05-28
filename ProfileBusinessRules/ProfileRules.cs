using System;
using ProfileDataModels;
using ProfileDataLayer;

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
	
	public void EditProfileInformation(string username, string information, string updatedInformation)
	{
		var allProfileAccounts = GetAllProfileAccounts();
		
		foreach (var account in allProfileAccounts)
		{
			if (username == account.username)
			{
				if (information == "Gender Pronouns")
				{
					account.genderPronouns = updatedInformation;
				}
				else if (information == "Bio")
				{
					account.bio = updatedInformation;
				}
			}
		}
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
	
	public string GenerateProfileLink(string username)
	{
		ProfileAccount account = GetProfileAccountByUsername(username);
		string profileLink = "https://www.puphub.com/" + account.username;
		
		return profileLink;
	}

}
