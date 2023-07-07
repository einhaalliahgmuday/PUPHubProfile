using System;
using ProfileDataModels;
using ProfileDataLayer;

namespace ProfileBusinessRules;

public class ProfileRules
{
	InMemoryProfileData profileData = new InMemoryProfileData();
	ProfileDataService dataService = new ProfileDataService();
	
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
	
	public void CreateAccount(string pstudentNo, string pusername, string pgenderPronouns, string pbio)		//draft
	{
		ProfileAccount profile = new ProfileAccount{
			username = pusername,
			genderPronouns = pgenderPronouns,
			rating = "0",
			dateJoined = DateTime.Now,
			bio = pbio
		};
		
		RegisteredAccount registered = new RegisteredAccount{
			studentNo = pstudentNo,
			username = pusername
		};
		
		dataService.CreateProfileAccount(profile);
		dataService.RegisterAccount(registered);
	}
	
	public void EditProfileInformation(string username, string informationToUpdate, string updatedInformation)
	{
		var allProfileAccounts = GetAllProfileAccounts();
		
		foreach (var account in allProfileAccounts)
		{
			if (username == account.username)
			{
				dataService.UpdateTheProfileAccount(account, informationToUpdate, updatedInformation);
				
				// if (information == "Gender Pronouns")
				// {
					// account.genderPronouns = updatedInformation;
				// }
				// else if (information == "Bio")
				// {
					// account.bio = updatedInformation;
				// }
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
