using System;
using ProfileDataModels;

namespace ProfileBusinessRules;

public class VisitingProfileRules
{
	ProfileRules profileRules = new ProfileRules();
	FollowStatus followStatus;
		
	public FollowStatus GetFollowStatus(string userUsername, string visitingProfileUsername) 
	{	
		var account = profileRules.GetProfileAccountByUsername(userUsername);
		
		foreach (var acc in account.following)
		{
			if (acc.username == visitingProfileUsername)
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
	
	public String GenerateFollowOption(string userUsername, string visitingProfileUsername)
	{
		var followStatus = GetFollowStatus(userUsername, visitingProfileUsername); 
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
	
	public bool IsProfileAccountBlocked(String userUsername, String username)
	{
		bool isProfileAccountBlocked = false;
		var account = profileRules.GetProfileAccountByUsername(userUsername);
		
		foreach (var acc in account.blockedAccounts)
		{
			if (acc.username == username)
			{
				isProfileAccountBlocked = true;
				
				break;
			}
		}
		
		return isProfileAccountBlocked;
	}
	
	public bool IsUserAllowedToAccessThisProfilesInformation(String userUsername, String visitingProfileUsername)
	{
		bool isUserAllowedToAccessThisProfilesInformation = true;
		var followStatus = GetFollowStatus(userUsername, visitingProfileUsername);
		var account = profileRules.GetProfileAccountByUsername(visitingProfileUsername);
		
		if ((account.accountPrivacy == AccountPrivacy.Private && followStatus == FollowStatus.NotFollowing) 
			|| IsProfileAccountBlocked(userUsername, visitingProfileUsername))
		{
			isUserAllowedToAccessThisProfilesInformation = false;
		}
		
		return isUserAllowedToAccessThisProfilesInformation;
	}
}
