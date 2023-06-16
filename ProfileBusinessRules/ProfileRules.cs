using System;
using ProfileDataModels;
using ProfileDataLayer;

namespace ProfileBusinessRules;

public class ProfileRules
{
	InMemoryProfileData profileData = new InMemoryProfileData();
	AccountPrivacy accountPrivacy;
	FollowStatus followStatus;
	
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
	
	public List<ProfileAccount> GetSearchedAccountsInFollowList(string search, string username, string whichFollowList) 
	{
		var account = GetProfileAccountByUsername(username);
		List<ProfileAccount> searchedAccounts = new List<ProfileAccount>();
		
		if (whichFollowList == "Following")
		{
			searchedAccounts = Search(search, account.following);
		}
		else if (whichFollowList == "Followers")
		{
			searchedAccounts = Search(search, account.followers);
		}
		
		return searchedAccounts;
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
	
	public FollowStatus GetFollowStatus(string username, string profileUsername) 
	{	
		var account = GetProfileAccountByUsername(username);
		
		foreach (var acc in account.following)
		{
			if (acc.username == profileUsername)
			{
				followStatus = FollowStatus.Following;
				
				break;
			}
			else 
			{
				followStatus = FollowStatus.NotFollowing;
			}
		}
		
		return followStatus;
	}
	
	public String GenerateFollowOption(string username, string profileUsername)
	{
		var followStatus = GetFollowStatus(username, profileUsername); 
		String followOption = "";
		
		switch (followStatus)
		{
			case FollowStatus.Following:
				followOption = "Unfollow";
				
				break;
			case FollowStatus.NotFollowing:
				followOption = "Follow";
				
				break;
		}
		
		return followOption;
	}
	
	public bool CanUserViewThisProfilesInformation(String usersUsername, String visitingProfilesUsername)
	{
		bool canUserViewThisProfilesInformation = true;
		var followStatus = GetFollowStatus(usersUsername, visitingProfilesUsername);
		var account = GetProfileAccountByUsername(visitingProfilesUsername);
		
		if (account.accountPrivacy == AccountPrivacy.Private && followStatus == FollowStatus.NotFollowing)
		{
			canUserViewThisProfilesInformation = false;
		}
		
		return canUserViewThisProfilesInformation;
	}
	
	// public bool CanUserViewThisProfilesInformation(ProfileAccount user, ProfileAccount visitingProfile)
	// {
		// bool canUserViewThisProfilesInformation = true;
		// var followStatus = GetFollowStatus(user.username, visitingProfile.username);
		
		// if (visitingProfile.accountPrivacy == AccountPrivacy.Private && followStatus == FollowStatus.NotFollowing)
		// {
			// canUserViewThisProfilesInformation = false;
		// }
		
		// return canUserViewThisProfilesInformation;
	// }
}
