using System;
using ProfileBusinessRules;
using ProfileDataModels;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Profile
{
	internal class Program
	{	
		public static string userUsername = "NelsonAbn";
		public static string visitingProfileUsername;
		public static int input;
	
		public static ProfileRules profileRules = new ProfileRules();
		public static RegistrationRules registrationRules = new RegistrationRules();
		public static VisitingProfileRules visitingProfileRules = new VisitingProfileRules();
		
		public static void Main(string[] args)
		{
			ViewMain();
		}
		
		static void ViewMain()
		{
			do
			{
				MakeSpace();
				ShowMainMenu();
				Console.WriteLine();
				ProcessUserActionInMainMenu();
			}
			while(input != 0);
		}
		
		static void ShowMainMenu() 
		{
			Console.WriteLine("----------MAIN MENU----------");
            Console.WriteLine("1 | List of Profile Accounts");
			Console.WriteLine("2 | Login");
            Console.WriteLine("3 | Register");
			Console.WriteLine("4 | Delete an account");
			Console.WriteLine("0 | Exit");
            Console.WriteLine("-----------------------------");
            GetUserInput();
		}
		
		static void ProcessUserActionInMainMenu()
		{
			string studentNo, username, genderPronouns, bio;
			
			switch (input)
			{	
				case 1:
					var allRegisteredAccounts = registrationRules.GetAllRegisteredAccounts();
					
					foreach (var account in allRegisteredAccounts)
					{
						Console.WriteLine("{0}		{1}", account.studentNo, account.username);
					}
					
					GoBack();
					
					break;
				case 2:
					Console.Write("Enter your Student No: ");
					studentNo = Console.ReadLine();
					Console.WriteLine();
					
					if (registrationRules.IsAccountRegistered(studentNo)) 
					{
						DisplayProfile("2021-00413-BN-0", "NelsonAbn");		//Edit here, auto username
					}
					else 
					{
						Console.WriteLine("Account is not registered.");		// Option to register account
					}
					
					break;
				case 3:
					Console.Write("Student No: ");
					studentNo = Console.ReadLine();
					
					if (registrationRules.IsAccountRegistered(studentNo))
					{
						Console.WriteLine("Account is already registered.");
					}
					else
					{
						if (profileRules.IsStudentExists(studentNo))
						{
							do 
							{
								Console.Write("Username: ");
								username = Console.ReadLine();
								
								if (registrationRules.IsUsernameExists(username))
								{
									Console.WriteLine("Username already exists.");
								}
							}
							while (registrationRules.IsUsernameExists(username));
							
							Console.WriteLine("Fill in other information? (Y/N)");
							char inputYN = Convert.ToChar(Console.ReadLine());
							
							switch (inputYN)
							{
								case 'Y': case 'y':
									Console.WriteLine("Gender Pronouns: ");
									genderPronouns = Console.ReadLine();
									Console.WriteLine("Bio");
									bio = Console.ReadLine();
									
									registrationRules.CreateAccount(studentNo, username, genderPronouns, bio);
									
									break;
								case 'N': case 'n':
									registrationRules.CreateAccount(studentNo, username);
									
									break;
								default:
									Console.WriteLine("Please enter a valid input.");
									break;
							}	
						}
						else 
						{
							Console.WriteLine("Student has no SIS account. Only students with SIS account can register.");
						}
					}
					
					break;
				case 4:
					Console.Write("Enter Student No: ");
					studentNo = Console.ReadLine();
					
					if (registrationRules.IsAccountRegistered(studentNo)) 
					{
						registrationRules.DeleteAccount(studentNo);
						Console.WriteLine("Account successfully deleted.");
					}
					else 
					{
						Console.WriteLine("Account does not exists.");
					}
					
					break;
				case 0:
					Console.WriteLine("Exiting...");
					
					break;
				default:
					Console.WriteLine("Please enter a valid input.");
					
					break;
			}
		}
		
		// static void ViewUserProfile()
		// {
			// DisplayProfile(userUsername);
			// ShowMainMenu();
			// ProcessUserActionInMainMenu();
		// }
		
		static void DisplayProfile(string studentNo, string username)
		{
			var profileAccount = profileRules.GetProfileAccountByUsername(username);
			var sisAccount = profileRules.GetSISAccountByStudentNo(studentNo);
			
			Console.WriteLine("{0}	{1}", sisAccount.name, profileAccount.genderPronouns);
			Console.WriteLine(profileAccount.username);
			Console.WriteLine("{0}	Joined {1}", profileAccount.rating, profileAccount.dateJoined.ToString("y")); 

			Console.WriteLine();

			Console.WriteLine(profileAccount.bio);

			Console.WriteLine();
					
			Console.WriteLine("   {0}   Following	{1}   Followers", profileRules.GetFollowing(username).Count(), profileRules.GetFollowers(username).Count());
					
			Console.WriteLine();

			Console.WriteLine("About: ");
			Console.WriteLine("Student of {0}", sisAccount.courYrSec);
			Console.WriteLine("Lives in {0}", sisAccount.location);
		}
		
        // static void ShowMainMenu()
        // {
            // Console.WriteLine("---PROFILE MENU---");
            // Console.WriteLine("1 | Search");
			// Console.WriteLine("2 | Edit Profile");
            // Console.WriteLine("3 | Following");
            // Console.WriteLine("4 | Followers");
            // Console.WriteLine("5 | Profile Link");
			// Console.WriteLine("6 | Log Out");
            // Console.WriteLine("-----------------");
            // GetUserInput();
        // }
		
        // static void ProcessUserActionInMainMenu()
        // {
            // switch (input)
            // {
                // case 1:
					// while(input != 0)
					// {
						// var allProfileAccounts = profileRules.GetAllProfileAccounts();
						
						// MakeSpace();
						// ShowSearchMenu();
						// MakeSpace();
						// ProcessUserActionInSearchMenu(allProfileAccounts);
					// }
					
                    // break;
				// case 2:
					// while(input != 0)
					// {	
						// MakeSpace();
						// ShowEditProfileMenu();
						// MakeSpace();
						// ProcessUserActionInEditProfileMenu();
					// }
					
                    // break;
                // case 3:
					// while(input != 0)
					// {
						// ViewFollowingAndProcessMenu(userUsername);
					// }
					
                    // break;
                // case 4:
					// while(input != 0)
					// {
						// ViewFollowersAndProcessMenu(userUsername);
					// }
					
                    // break;
                // case 5:
					// string profileLink = profileRules.GenerateProfileLink(userUsername);
					// Console.WriteLine("Your profile link: {0}", profileLink);
                    
					// GoBack();

                    // break;
				// case 6:

                    // break;
            // }
        // }
		
		// static void ShowEditProfileMenu()
		// {
			// Console.WriteLine("----EDIT PROFILE----");
			// Console.WriteLine("1 | Edit Gender Pronouns");
			// Console.WriteLine("2 | Edit Bio");
			// Console.WriteLine("0 | Go back");
			// Console.WriteLine("--------------------");
			// GetUserInput();
		// }
		
		// static void ProcessUserActionInEditProfileMenu()
		// {	
			// string updatedInformation;
		
			// switch (input)
			// {
				// case 0:
					// ViewProfileMain();
					
					// break;
				// case 1:
					// updatedInformation = GetUpdatedInformation("Gender Pronouns");
					// profileRules.EditProfileInformation(userUsername, "genderPronouns", updatedInformation);
					
					// break;
				// case 2:
					// updatedInformation = GetUpdatedInformation("Bio");
					// profileRules.EditProfileInformation(userUsername, "bio", updatedInformation);
					
					// break;
				// }
		// }
		
		// static string GetUpdatedInformation(string information)
		// {
			// Console.Write("Enter updated {0}: ", information);
			// string updatedInformation = Console.ReadLine();
			
			// return updatedInformation;
		// }
		
		// static void DisplayFollowingList(string username)
		// {
			// var account = profileRules.GetProfileAccountByUsername(username);
			
			// Console.WriteLine("FOLLOWING: ");
			// Console.WriteLine();
			// foreach (var following in account.following)
			// {
				// Console.WriteLine("{0}   		{1}", following.name, following.username);
			// }
		// }
		
		// static void DisplayFollowersList(string username)
		// {
			// var account = profileRules.GetProfileAccountByUsername(username);
			
			// Console.WriteLine("FOLLOWERS: ");
			// Console.WriteLine();
			// foreach (var follower in account.followers)
			// {
				// Console.WriteLine("{0}   		{1}", follower.name, follower.username);
			// }
		// }

		// static void ShowSearchMenu()
		// {
			// Console.WriteLine("---SEARCH MENU---");
			// Console.WriteLine("1 | Search");
			// Console.WriteLine("2 | Visit Profile");
			// Console.WriteLine("0 | Go back");
			// Console.WriteLine("-----------------");
			// GetUserInput();
		// }
		
		// static void ProcessUserActionInSearchMenu(List<ProfileAccount> list)
		// {	
			// switch (input)
			// {
				// case 0:
					// ViewProfileMain();
					
					// break;
				// case 1:
					// Console.Write("Search: ");
					// string search = Console.ReadLine();
					// MakeSpace();
					
					// var searchedAccounts = profileRules.Search(search, list);
					
					// foreach (var account in searchedAccounts)
					// {
						// if (visitingProfileRules.IsProfileAccountBlocked(userUsername, account.username))	//business rule?
						// {
							// continue;
						// }
						// else 
						// {
							// Console.WriteLine("{0}   		{1}", account.name, account.username);
						// }
					// }
					
					// GoBack();
					
					// break;
				// case 2:
					// Console.Write("Enter profile username to visit: ");
					// visitingProfileUsername = Console.ReadLine();
					// MakeSpace();
					
					// if (visitingProfileUsername == userUsername)
					// {
						// ViewProfileMain();
					// }
					// else
					// {
						// ViewOthersProfile();
					// }
					
					// break;
			// }
		// }
		
		// static void ViewVisitingProfile()
		// {
			// DisplayProfile(visitingProfileUsername);
			// MakeSpace();
			// ShowVisitingProfileMenu();
			// ProcessUserActionInVisitingProfileMenu();
		// }
		
		// static void ShowVisitingProfileMenu()
		// {
			// String followOption = visitingProfileRules.GenerateFollowOption(userUsername, visitingProfileUsername);
			
			// Console.WriteLine("-------MENU-------");
			// Console.WriteLine("1 | {0}", followOption);
			// Console.WriteLine("2 | Message");
			// Console.WriteLine("3 | Following");
			// Console.WriteLine("4 | Followers");
			// Console.WriteLine("5 | View Timeline");
			// Console.WriteLine("6 | Options");
			// Console.WriteLine("0 | Go Back");
			// Console.WriteLine("------------------");
			// GetUserInput();
		// }
		
		// static void ProcessUserActionInVisitingProfileMenu()
		// {
			
			// switch (input)
			// {
				// case 0:
					// ViewProfileMain();
					
					// break;
				// case 1:
					
					// GoBack();
					
					// break;
				// case 2:
					
					// GoBack();
					
					// break;
				// case 3:
					// while(input != 0)
					// {
						// if (visitingProfileRules.IsUserAllowedToAccessThisProfilesInformation(userUsername, visitingProfileUsername))
						// {
							// ViewFollowingAndProcessMenu(visitingProfileUsername);
						// }
					// }
					
					// break;
				// case 4:
					// while(input != 0)
					// {
						// if (visitingProfileRules.IsUserAllowedToAccessThisProfilesInformation(userUsername, visitingProfileUsername))	//this
						// {
							// ViewFollowersAndProcessMenu(visitingProfileUsername);
						// }
					// }
					
					// break;
				// case 5:
					
					// GoBack();
					
					// break;
				// case 6:
					// while(input != 0)
					// {
						// MakeSpace();
						// ShowVisitingProfileOptionsMenu();
						// MakeSpace();
						// ProcessUserActionInVisitingProfileOptionsMenu();
					// }
					
					// break;
			// }
		// }
		
		// static void ShowVisitingProfileOptionsMenu()
		// {
			// Console.WriteLine("-------OPTIONS-------");
			// Console.WriteLine("1 | View profile link");
			// Console.WriteLine("2 | Block");
			// Console.WriteLine("3 | Report");
			// Console.WriteLine("0 | Go back");
			// Console.WriteLine("---------------------");
			// GetUserInput();
		// }
		
		// static void ProcessUserActionInVisitingProfileOptionsMenu()
		// {
			// switch (input)
            // {
                // case 0:
                    // ViewOthersProfile();

                    // break;
                // case 1:
					// string profileLink = profileRules.GenerateProfileLink(visitingProfileUsername);
					// Console.WriteLine("This profile account's link: {0}", profileLink);
					
					// GoBack();
					
                    // break;
                // case 2:
                    
					
					// GoBack();

                    // break;
				// case 3:
                    
					
					// GoBack();

                    // break;
            // }
		// }
		
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