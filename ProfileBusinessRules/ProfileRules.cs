using System;
using ProfileDataModels;
using ProfileDataLayer;

namespace ProfileBusinessRules;

public class ProfileRules
{
	ProfileDataService dataService = new ProfileDataService();
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
