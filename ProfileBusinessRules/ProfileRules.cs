using System;
using ProfileDataModels;
using ProfileDataLayer;

namespace ProfileBusinessRules;

public class ProfileRules
{
	ProfileDataService dataService = new ProfileDataService();
	InMemorySISData sisData = new InMemorySISData();
	InMemoryFollowData followData = new InMemoryFollowData();
	// InMemoryProfileData profileData = new InMemoryProfileData();
	
	public List<ProfileAccount> GetAllProfileAccounts()
	{
		// return profileData.GetProfileAccounts();
		return dataService.GetAllTheProfileAccounts();
	}
	
	public ProfileAccount GetProfileAccountByUsername(string username)
	{
		var allProfileAccounts = GetAllProfileAccounts();
		var foundAccount = new ProfileAccount();
		
		foreach (var account in allProfileAccounts)
		{
			if (username == account.username)
			{
				foundAccount = account;
			}
		}
		
		return foundAccount;
	}
	
	public SISAccount GetSISAccountByStudentNo(string studentNo)
	{
		SISAccount foundAccount = new SISAccount();
		var allSISAccounts = sisData.GetSISAccounts();
		
		foreach (var account in allSISAccounts)
		{
			if (account.studentNo == studentNo)
			{
				foundAccount = account;
			}
		}
		
		return foundAccount;
	}
	
	public bool IsStudentExists(string studentNo)
	{
		bool IsAccountExists = false;
		var allSISAccounts = sisData.GetSISAccounts();
		
		foreach (var account in allSISAccounts) 
		{
			if (account.studentNo == studentNo)
			{
				IsAccountExists = true;
				break;
			}
		}
		
		return IsAccountExists;
	}
	
	public List<ProfileAccount> GetFollowers(string username)
	{
		List<ProfileAccount> followers = new List<ProfileAccount>();
		var allFollowData = followData.GetFollowData();
		
		foreach (var follow in allFollowData)
		{
			if (follow.following == username) 
			{
				var account = GetProfileAccountByUsername(follow.follower);
				followers.Add(account);
			}
		}
		
		return followers;
	}
	
	public List<ProfileAccount> GetFollowing(string username)
	{
		List<ProfileAccount> following = new List<ProfileAccount>();
		var allFollowData = followData.GetFollowData();
		
		foreach (var follow in allFollowData)
		{
			if (follow.follower == username) 
			{
				var account = GetProfileAccountByUsername(follow.following);
				following.Add(account);
			}
		}
		
		return following;
	}
	
	public void EditProfileInformation(string username, string informationToUpdate, string updatedInformation)
	{
		var allProfileAccounts = GetAllProfileAccounts();
		
		foreach (var account in allProfileAccounts)
		{
			if (username == account.username)
			{
				dataService.UpdateTheProfileAccount(account, informationToUpdate, updatedInformation);
			}
		}
	}
	
	public string GenerateProfileLink(string username)
	{
		ProfileAccount account = GetProfileAccountByUsername(username);
		string profileLink = "https://www.puphub.com/" + account.username;
		
		return profileLink;
	}
	
		
	public List<ProfileAccount> Search(string search, List<ProfileAccount> list)
	{
		List<ProfileAccount> searchedAccounts = new List<ProfileAccount>();
		
		foreach (var account in list)
		{
			if (account.username.Contains(search)) 
			{
				searchedAccounts.Add(account);
			}
		}
		
		return searchedAccounts;
	}
}
