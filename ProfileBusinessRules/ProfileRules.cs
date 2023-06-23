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
	
	// public bool DoesProfileAccountExistsInTheList(string username, List<ProfileAccount> list)	//parameter userUsername
	// {
		// bool doesProfileAccountExistsInTheList = false;
		
		// foreach (var account in list) 
		// {
			// if (account.username == username) 
			// {
				// doesProfileAccountExistsInTheList = true;
			// }
		// }
		
		// return doesProfileAccountExistsInTheList;
	// }
}
