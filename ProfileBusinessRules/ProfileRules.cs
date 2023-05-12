using System;
using DataLayer;

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
		
	public static void ViewFollowers()
	{
		Console.WriteLine("Followers:");
		foreach (var follows in User.followersList)
		{
			Console.WriteLine(follows);
		}
	}
	
	public static void GenerateProfileLink()
	{
		Console.WriteLine("Your profile link: https://www.puphub.com/{0}", User.username);
	}

}
