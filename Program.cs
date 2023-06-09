﻿using System;
using ProfileBusinessRules;
using ProfileDataModels;
using System.Data.SqlClient;

namespace Profile
{
	internal class Program
	{	
		public static ProfileRules profileRules = new ProfileRules();
		public static VisitingProfileRules visitingProfileRules = new VisitingProfileRules();
		public static string userUsername = "juandelacruz";
		public static string visitingProfileUsername;
		public static int input;
		
		public static void Main(string[] args)
		{
			ViewProfileMain();

			// profileRules.CreateAccount("0000-00000-BB-0", "juanadelacruz", "she/her", "");
			// profileRules.EditProfileInformation("juanadelacruz", "bio", "Hello");

			// var profileAccounts = profileRules.GetAllProfileAccounts();
			// foreach (var account in profileAccounts) 
			// {
				// Console.WriteLine(account.username);
			// }
		}
		
		static void ViewProfileMain()
        {	
			MakeSpace();
			DisplayProfile(userUsername);
			MakeSpace();		
            ShowMainMenu();
            ProcessUserActionInMainMenu();
        }
		
		static void DisplayProfile(string username)
		{
			var account = profileRules.GetProfileAccountByUsername(username);
			
			Console.WriteLine("{0}	{1}", account.name, account.genderPronouns);
			Console.WriteLine(account.username);
			Console.WriteLine("{0}	Joined {1}", account.rating, account.dateJoined.ToString("y")); 

			Console.WriteLine();

			Console.WriteLine(account.bio);

			Console.WriteLine();
					
			Console.WriteLine("   {0}   Following	{1}   Followers", account.followers.Count(), account.following.Count());
					
			Console.WriteLine();

			Console.WriteLine("About: ");
			Console.WriteLine("Student of {0}", account.courYrSec);
			Console.WriteLine("Lives in {0}", account.location);
		}
		
        static void ShowMainMenu()
        {
            Console.WriteLine("----MAIN MENU----");
            Console.WriteLine("1 | Search");
			Console.WriteLine("2 | Edit Profile");
            Console.WriteLine("3 | View Timeline");
            Console.WriteLine("4 | Following");
            Console.WriteLine("5 | Followers");
            Console.WriteLine("6 | Add Post");
            Console.WriteLine("7 | Options");
            Console.WriteLine("-----------------");
            GetUserInput();
        }
		
        static void ProcessUserActionInMainMenu()
        {
            switch (input)
            {
                case 1:
					while(input != 0)
					{
						var allProfileAccounts = profileRules.GetAllProfileAccounts();
						
						MakeSpace();
						ShowSearchMenu();
						MakeSpace();
						ProcessUserActionInSearchMenu(allProfileAccounts);
					}
					
                    break;
				case 2:
					while(input != 0)
					{	
						MakeSpace();
						ShowEditProfileMenu();
						MakeSpace();
						ProcessUserActionInEditProfileMenu();
					}
					
                    break;
                case 3:
					
					
					GoBack();
					ViewProfileMain();
				
                    break;
                case 4:
					while(input != 0)
					{
						ViewFollowingAndProcessMenu(userUsername);
					}
					
                    break;
                case 5:
					while(input != 0)
					{
						ViewFollowersAndProcessMenu(userUsername);
					}
					
                    break;
                case 6:
				
				
					GoBack();
					ViewProfileMain();
					
                    break;
                case 7:
					while(input != 0)
					{
						MakeSpace();
						ShowOptionsMenu();
						MakeSpace();
						ProcessUserActionInOptionsMenu();
					}

                    break;
            }
        }
		
		static void ShowEditProfileMenu()
		{
			Console.WriteLine("----EDIT PROFILE----");
			Console.WriteLine("1 | Edit Gender Pronouns");
			Console.WriteLine("2 | Edit Bio");
			Console.WriteLine("0 | Go back");
			Console.WriteLine("--------------------");
			GetUserInput();
		}
		
		static void ProcessUserActionInEditProfileMenu()
		{	
			string updatedInformation;
		
			switch (input)
			{
				case 0:
					ViewProfileMain();
					
					break;
				case 1:
					updatedInformation = GetUpdatedInformation("Gender Pronouns");
					profileRules.EditProfileInformation(userUsername, "Gender Pronouns", updatedInformation);
					
					break;
				case 2:
					updatedInformation = GetUpdatedInformation("Bio");
					profileRules.EditProfileInformation(userUsername, "Bio", updatedInformation);
					
					break;
				}
		}
		
		static string GetUpdatedInformation(string information)
		{
			Console.Write("Enter updated {0}: ", information);
			string updatedInformation = Console.ReadLine();
			
			return updatedInformation;
		}
		
		static void ShowOptionsMenu()
        {
			Console.WriteLine("-------OPTIONS-------");
			Console.WriteLine("1 | View profile link");
			Console.WriteLine("2 | Settings");
			Console.WriteLine("0 | Go back");
			Console.WriteLine("---------------------");
			GetUserInput();
        }

        static void ProcessUserActionInOptionsMenu()
        {
            switch (input)
            {
                case 0:
                    ViewProfileMain();

                    break;
                case 1:
                    string profileLink = profileRules.GenerateProfileLink(userUsername);
					Console.WriteLine("Your profile link: {0}", profileLink);
                    
					GoBack();
					
                    break;
                case 2:
                    
					
					GoBack();

                    break;
            }
        }
		
		static void ViewFollowingAndProcessMenu(string username)
		{
			var account = profileRules.GetProfileAccountByUsername(username);
			
			MakeSpace();
			DisplayFollowingList(username);
			MakeSpace();
			ShowSearchMenu();
			MakeSpace();
			ProcessUserActionInSearchMenu(account.following);
		}
		
		static void ViewFollowersAndProcessMenu(string username)
		{	
			var account = profileRules.GetProfileAccountByUsername(username);
			
			MakeSpace();
			DisplayFollowingList(username);
			MakeSpace();
			ShowSearchMenu();
			MakeSpace();
			ProcessUserActionInSearchMenu(account.followers);
		}
		
		static void DisplayFollowingList(string username)
		{
			var account = profileRules.GetProfileAccountByUsername(username);
			
			Console.WriteLine("FOLLOWING: ");
			Console.WriteLine();
			foreach (var following in account.following)
			{
				Console.WriteLine("{0}   		{1}", following.name, following.username);
			}
		}
		
		static void DisplayFollowersList(string username)
		{
			var account = profileRules.GetProfileAccountByUsername(username);
			
			Console.WriteLine("FOLLOWERS: ");
			Console.WriteLine();
			foreach (var follower in account.followers)
			{
				Console.WriteLine("{0}   		{1}", follower.name, follower.username);
			}
		}

		static void ShowSearchMenu()
		{
			Console.WriteLine("---SEARCH MENU---");
			Console.WriteLine("1 | Search");
			Console.WriteLine("2 | Visit Profile");
			Console.WriteLine("0 | Go back");
			Console.WriteLine("-----------------");
			GetUserInput();
		}
		
		static void ProcessUserActionInSearchMenu(List<ProfileAccount> list)
		{	
			switch (input)
			{
				case 0:
					ViewProfileMain();
					
					break;
				case 1:
					Console.Write("Search: ");
					string search = Console.ReadLine();
					MakeSpace();
					
					var searchedAccounts = profileRules.Search(search, list);
					
					foreach (var account in searchedAccounts)
					{
						if (visitingProfileRules.IsProfileAccountBlocked(userUsername, account.username))	//business rule?
						{
							continue;
						}
						else 
						{
							Console.WriteLine("{0}   		{1}", account.name, account.username);
						}
					}
					
					GoBack();
					
					break;
				case 2:
					Console.Write("Enter profile username to visit: ");
					visitingProfileUsername = Console.ReadLine();
					MakeSpace();
					
					if (visitingProfileUsername == userUsername)
					{
						ViewProfileMain();
					}
					else
					{
						ViewOthersProfile();
					}
					
					break;
			}
		}
		
		static void ViewOthersProfile()
		{
			DisplayProfile(visitingProfileUsername);
			MakeSpace();
			ShowVisitingProfileMenu();
			ProcessUserActionInVisitingProfileMenu();
		}
		
		static void ShowVisitingProfileMenu()
		{
			String followOption = visitingProfileRules.GenerateFollowOption(userUsername, visitingProfileUsername);
			
			Console.WriteLine("-------MENU-------");
			Console.WriteLine("1 | {0}", followOption);
			Console.WriteLine("2 | Message");
			Console.WriteLine("3 | Following");
			Console.WriteLine("4 | Followers");
			Console.WriteLine("5 | View Timeline");
			Console.WriteLine("6 | Options");
			Console.WriteLine("0 | Go Back");
			Console.WriteLine("------------------");
			GetUserInput();
		}
		
		static void ProcessUserActionInVisitingProfileMenu()
		{
			
			switch (input)
			{
				case 0:
					ViewProfileMain();
					
					break;
				case 1:
					
					GoBack();
					
					break;
				case 2:
					
					GoBack();
					
					break;
				case 3:
					while(input != 0)
					{
						if (visitingProfileRules.IsUserAllowedToAccessThisProfilesInformation(userUsername, visitingProfileUsername))
						{
							ViewFollowingAndProcessMenu(visitingProfileUsername);
						}
					}
					
					break;
				case 4:
					while(input != 0)
					{
						if (visitingProfileRules.IsUserAllowedToAccessThisProfilesInformation(userUsername, visitingProfileUsername))	//this
						{
							ViewFollowersAndProcessMenu(visitingProfileUsername);
						}
					}
					
					break;
				case 5:
					
					GoBack();
					
					break;
				case 6:
					while(input != 0)
					{
						MakeSpace();
						ShowVisitingProfileOptionsMenu();
						MakeSpace();
						ProcessUserActionInVisitingProfileOptionsMenu();
					}
					
					break;
			}
		}
		
		static void ShowVisitingProfileOptionsMenu()
		{
			Console.WriteLine("-------OPTIONS-------");
			Console.WriteLine("1 | View profile link");
			Console.WriteLine("2 | Block");
			Console.WriteLine("3 | Report");
			Console.WriteLine("0 | Go back");
			Console.WriteLine("---------------------");
			GetUserInput();
		}
		
		static void ProcessUserActionInVisitingProfileOptionsMenu()
		{
			switch (input)
            {
                case 0:
                    ViewOthersProfile();

                    break;
                case 1:
					string profileLink = profileRules.GenerateProfileLink(visitingProfileUsername);
					Console.WriteLine("This profile account's link: {0}", profileLink);
					
					GoBack();
					
                    break;
                case 2:
                    
					
					GoBack();

                    break;
				case 3:
                    
					
					GoBack();

                    break;
            }
		}
		
		static int GetUserInput()
        {
            Console.Write("Your input: ");
            input = Convert.ToInt32(Console.ReadLine());

            return input;
        }

        static void GoBack()
        {
			MakeSpace();
			
			Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }
		
		static void MakeSpace() 
		{
			Console.WriteLine();
			Console.WriteLine();
		}
    }
}