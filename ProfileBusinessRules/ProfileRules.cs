using System;
using ProfileDataModels;
using ProfileDataLayer;

namespace ProfileBusinessRules;

public class ProfileRules
{	
	public static void ViewProfileInformation()
        {
            Console.WriteLine("{0}	{1}", User.name, User.gender);
            Console.WriteLine(User.username);
            Console.WriteLine(User.rating);

            Console.WriteLine();

            Console.WriteLine(User.bio);

            Console.WriteLine();
			
			Console.WriteLine("{0} Following	{1} Followers", User.followingList.Count, User.followersList.Count);
			
			Console.WriteLine();

            Console.WriteLine("About: ");
            Console.WriteLine("Student of {0}", User.courseYrSec);
            Console.WriteLine("Lives in {0}", User.location);

            Console.WriteLine();
            Console.WriteLine();
        }
	
	public static void UpdateProfile(string info)
    {
		if (info == "Name")
		{
			EditProfileInformation(info, ref User.name);
			Console.WriteLine("{0} updated!", info);
		}
		else if (info == "Username")
		{
			EditProfileInformation(info, ref User.username);
			Console.WriteLine("{0} updated!", info);
		}
		else if (info == "Gender Pronouns")
		{
			EditProfileInformation(info, ref User.gender);
			Console.WriteLine("{0} updated!", info);
		}
		else if (info == "Bio")
		{
			EditProfileInformation(info, ref User.bio);
			Console.WriteLine("{0} updated!", info);
		}
		else if (info == "Course, Year & Section")
		{
			EditProfileInformation(info, ref User.courseYrSec);
			Console.WriteLine("{0} updated!", info);
		}
		else if (info == "Location")
		{
			EditProfileInformation(info, ref User.location);
			Console.WriteLine("{0} updated!", info);
		}
    }
	
	public static void EditProfileInformation(string info, ref string updatedValue)
	{
		Console.Write("Enter {0}: ", info);
		updatedValue = Console.ReadLine();
	}
	
	public static void ViewFollowing()
		{
			Console.WriteLine("Following:");
			foreach (var follows in User.followingList)
			{
				Console.WriteLine(follows);
			}
		}
		
<<<<<<< Updated upstream
	public static void ViewFollowers()
	{
		Console.WriteLine("Followers:");
		foreach (var follows in User.followersList)
		{
			Console.WriteLine(follows);
=======
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
>>>>>>> Stashed changes
		}
	}
	
	public static void GenerateProfileLink()
	{
<<<<<<< Updated upstream
		Console.WriteLine("Your profile link: https://www.puphub.com/{0}", User.username);
=======
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
>>>>>>> Stashed changes
	}

}
