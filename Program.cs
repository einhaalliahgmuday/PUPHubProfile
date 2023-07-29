using System;
using ProfileBusinessRules;
using ProfileDataModels;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Profile
{
	internal class Program
	{	
		public static ProfileRules profileRules = new ProfileRules();
		public static RegistrationRules registrationRules = new RegistrationRules();
	
		public static RegisteredAccount user = new RegisteredAccount();
		public static RegisteredAccount visitingProfile = new RegisteredAccount();
		public static int input;
		
		public static void Main(string[] args)
		{
			ViewMain();
		}
		
		static void ViewMain()
		{
			do
			{
				Console.WriteLine();
				Console.WriteLine();
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
			
			switch (input)
			{	
				case 1:
					DisplayAllProfileAccounts();
					
					break;
				case 2:
					Login();
					
					break;
				case 3:
					Register();
					
					break;
				case 4:
					DeleteProfileAccount();
					
					break;
				case 0:
					
					break;
				default:
					Console.WriteLine("Please enter a valid input.");
					
					break;
			}
		}
		
		static void DisplayAllProfileAccounts()
		{
			var allRegisteredAccounts = registrationRules.GetAllRegisteredAccounts();
					
			foreach (var account in allRegisteredAccounts)
			{
				var sisAccount = profileRules.GetSISAccountByStudentNo(account.studentNo);
				if (sisAccount.name.Length < 16)
				{
					Console.WriteLine("{0}		{1}				{2}", account.studentNo, sisAccount.name, account.username);
				}
				else if (sisAccount.name.Length > 23)
				{
					Console.WriteLine("{0}		{1}		{2}", account.studentNo, sisAccount.name, account.username);
				}
				else
				{
					Console.WriteLine("{0}		{1}			{2}", account.studentNo, sisAccount.name, account.username);
				}
			}
		}
		
		static void Login()
		{
			Console.Write("Enter your Student No: ");
			string studentNo = Console.ReadLine();
			Console.WriteLine();
					
			if (registrationRules.IsAccountRegistered(studentNo)) 
			{
				user = registrationRules.GetRegisteredAccountByStudentNo(studentNo);
				ViewUserProfile();
			}
			else 
			{
				if (registrationRules.IsStudentExists(studentNo))
				{
					Console.Write("Student is not yet registered. Register? (Y/N) ");
					char inputYN = Convert.ToChar(Console.ReadLine());
						
					switch (inputYN)
					{
						case 'Y': case 'y':
							Console.WriteLine();
							Register();
							
							break;
						case 'N': case 'n':
					
							break;
						default:
							Console.WriteLine("Invalid Input");
							break;
					}
				}
				else 
				{
					Console.WriteLine("Profile not found.");
				}
			}
		}
		
		static void Register()
		{
			string studentNo, username, genderPronouns, bio;
			
			Console.Write("Student No: ");
			studentNo = Console.ReadLine();
					
			if (registrationRules.IsAccountRegistered(studentNo))
			{
				Console.WriteLine("Account is already registered.");
			}
			else
			{
				if (registrationRules.IsStudentExists(studentNo))
				{
					do 
					{
						Console.Write("Username: ");
						username = Console.ReadLine();
						
						if (registrationRules.IsUsernameExists(username))
						{
							Console.WriteLine("Username is already taken.");
						}
					}
					while (registrationRules.IsUsernameExists(username));
					
					Console.Write("Fill in other information? (Y/N) ");
					char inputYN = Convert.ToChar(Console.ReadLine());
					
					switch (inputYN)
					{
						case 'Y': case 'y':
							Console.Write("Gender Pronouns: ");
							genderPronouns = Console.ReadLine();
							Console.Write("Bio: ");
							bio = Console.ReadLine();
							
							try
							{
								registrationRules.CreateAccount(studentNo, username, genderPronouns, bio);
								Console.WriteLine();
								Console.WriteLine("Registration successful!");
								Console.WriteLine();
							
								user = registrationRules.GetRegisteredAccountByStudentNo(studentNo);
								ViewUserProfile();
							}
							catch (Exception e)
							{
								Console.WriteLine("Registration failed.");
							}
							
							break;
						case 'N': case 'n':
							try
							{
								registrationRules.CreateAccount(studentNo, username);
								Console.WriteLine();
								Console.WriteLine("Registration successful!");
								Console.WriteLine();
							
								user = registrationRules.GetRegisteredAccountByStudentNo(studentNo);
								ViewUserProfile();
							}
							catch (Exception e)
							{
								Console.WriteLine("Registration failed.");
							}
					
							break;
						default:
							Console.WriteLine("Invalid Input");
							break;
					}	
				}
				else 
				{
					Console.WriteLine("Student not found. Only students with SIS account can register.");
				}
			}
		}
		
		static void DeleteProfileAccount()
		{
			Console.Write("Enter Student No: ");
			string studentNo = Console.ReadLine();
			
			if (registrationRules.IsAccountRegistered(studentNo)) 
			{
				registrationRules.DeleteAccount(studentNo);
				Console.WriteLine("Account successfully deleted.");
			}
			else 
			{
				Console.WriteLine("Account does not exists.");
			}
		}
		
		static void ViewUserProfile()
		{
			do 
			{
				Console.WriteLine();
				DisplayProfile(user);
				Console.WriteLine();
				ShowUserProfileMenu();
				Console.WriteLine();
				ProcessUserActionInUserProfileMenu();
			}
			while (input != 0);
		}
		
		static void DisplayProfile(RegisteredAccount registeredAccount)
		{
			var profileAccount = profileRules.GetProfileAccountByUsername(registeredAccount.username);
			var sisAccount = profileRules.GetSISAccountByStudentNo(registeredAccount.studentNo);
			string username = registeredAccount.username;
			
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
		
        static void ShowUserProfileMenu()
        {
            Console.WriteLine("---PROFILE MENU---");
            Console.WriteLine("1 | Search");
			Console.WriteLine("2 | Edit Profile");
            Console.WriteLine("3 | Following");
            Console.WriteLine("4 | Followers");
            Console.WriteLine("5 | Profile Link");
			Console.WriteLine("0 | Log Out");
            Console.WriteLine("-----------------");
            GetUserInput();
        }
		
        static void ProcessUserActionInUserProfileMenu()
        {
            switch (input)
            {
                case 1:
					while (input != 0)
					{
						ViewSearch(profileRules.GetAllProfileAccounts());
					}
					if (input == 0)
					{
						ViewUserProfile();
					}
					
                    break;
				case 2:
					while (input != 0)
					{
						Console.WriteLine();
						ShowEditProfileMenu();
						Console.WriteLine();
						ProcessUserActionInEditProfileMenu();
					}
					
                    break;
                case 3:
					ViewFollowing(user.username);
					
					if (input == 0)
					{
						ViewUserProfile();
					}
					
                    break;
                case 4:
					ViewFollowers(user.username);
					
					if (input == 0)
					{
						ViewUserProfile();
					}
					
                    break;
                case 5:
					DisplayProfileLink(user.username);
                    
					GoBack();

                    break;
				case 0:
					Console.WriteLine("Logged out.");
					ViewMain();
					
                    break;
				default:
					Console.WriteLine("Please enter a valid input.");
					
					break;
            }
        }
		
		static void ViewSearch(List<ProfileAccount> searchIn)
		{	
			Console.WriteLine();
			ShowSearchMenu();
			Console.WriteLine();
			ProcessUserActionInSearchMenu(searchIn);
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
		
		static void ProcessUserActionInSearchMenu(List<ProfileAccount> searchIn)
		{	
			switch (input)
			{
				case 1:
					Console.Write("Search: ");
					string search = Console.ReadLine();
					Console.WriteLine();
					
					var searchedAccounts = profileRules.Search(search, searchIn);
					
					if (searchedAccounts.Count == 0)
					{
						Console.WriteLine("No Results Found");
						Console.WriteLine();
					}
					else 
					{
						foreach (var account in searchedAccounts)
						{
							var registeredAccount = registrationRules.GetRegisteredAccountByUsername(account.username);
							var sisAccount = profileRules.GetSISAccountByStudentNo(registeredAccount.studentNo);
							
							if (sisAccount.name.Length < 16)
							{
								Console.WriteLine("{0}				{1}", sisAccount.name, account.username);
							}
							else if (sisAccount.name.Length > 23)
							{
								Console.WriteLine("{0}		{1}", sisAccount.name, account.username);
							}
							else
							{
								Console.WriteLine("{0}			{1}", sisAccount.name, account.username);
							}
						}
						
						Console.WriteLine();
					}
					
					break;
				case 2:
					Console.Write("Enter profile username to visit: ");
					string username = Console.ReadLine();
					Console.WriteLine();
					
					if (profileRules.IsAccountInTheList(username, searchIn))
					{
						if (username == user.username)
						{
							input = 0;
						}
						else
						{
							visitingProfile = registrationRules.GetRegisteredAccountByUsername(username);
							input = 0;
							ViewVisitingProfile();
						}
					}
					else
					{
						Console.WriteLine("Account not found.");
						Console.WriteLine();
						ViewSearch(searchIn);
					}
					
					break;
				case 0:
					
					break;
				default:
					Console.WriteLine("Please enter a valid input.");
					Console.WriteLine();
					
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
				case 1:
					Console.Write("Enter updated Gender Pronouns: ");
					updatedInformation = Console.ReadLine();
					
					try 
					{
						profileRules.EditProfileInformation(user.username, "Gender Pronouns", updatedInformation);
						Console.WriteLine("Gender Pronouns updated!");
					}
					catch (Exception e)
					{
						
					}
					
					break;
				case 2:
					Console.Write("Enter updated Bio: ");
					updatedInformation = Console.ReadLine();
					
					try 
					{
						profileRules.EditProfileInformation(user.username, "Bio", updatedInformation);
						Console.WriteLine("Bio updated!");
					}
					catch (Exception e)
					{
						
					}
					
					break;
				case 0:
					ViewUserProfile();
					
					break;
				default:
					Console.WriteLine("Please enter a valid input.");
					
					break;
			}
		}
		
		static void ViewFollowing(string username)
		{
			while (input != 0)
			{
				Console.WriteLine();
				DisplayFollowingList(username);
				Console.WriteLine();
				
				var followings = profileRules.GetFollowing(username);
				if (followings.Count == 0)
				{
					GoBack();
					input = 0;
				}
				else
				{
					ViewSearch(followings);
				}
			}
		}
		
		static void DisplayFollowingList(string username)
		{
			var followings = profileRules.GetFollowing(username);
			
			Console.WriteLine("FOLLOWING: ");
			Console.WriteLine();
			foreach (var following in followings)
			{
				Console.WriteLine("{0}   		", following.username);
			}
		}
		
		static void ViewFollowers(string username)
		{
			while (input != 0)
			{
				Console.WriteLine();
				DisplayFollowersList(username);
				Console.WriteLine();
				
				var followers = profileRules.GetFollowers(username);
				if (followers.Count == 0)
				{
					GoBack();
					input = 0;
				}
				else
				{
					ViewSearch(followers);
				}
			}
		}
		
		static void DisplayFollowersList(string username)
		{
			var followers = profileRules.GetFollowers(username);
			
			Console.WriteLine("FOLLOWERS: ");
			Console.WriteLine();
			foreach (var follower in followers)
			{
				Console.WriteLine("{0}   		", follower.username);
			}
		}
		
		static void DisplayProfileLink(string username)
		{
			string profileLink = profileRules.GenerateProfileLink(username);
			Console.WriteLine("This profile's link: {0}", profileLink);
		}
		
		static void ViewVisitingProfile()
		{
			do 
			{
				Console.WriteLine();
				DisplayProfile(visitingProfile);
				Console.WriteLine();
				ShowVisitingProfileMenu();
				Console.WriteLine();
				ProcessUserActionInVisitingProfileMenu();
			}
			while (input != 0);
		}
		
		static void ShowVisitingProfileMenu()
		{	
			Console.WriteLine("-------MENU-------");
			Console.WriteLine("1 | Following");
			Console.WriteLine("2 | Followers");
			Console.WriteLine("3 | Profile Link");
			Console.WriteLine("0 | Go Back");
			Console.WriteLine("------------------");
			GetUserInput();
		}
		
		static void ProcessUserActionInVisitingProfileMenu()
		{
			
			switch (input)
			{
				case 1:
					ViewFollowing(visitingProfile.username);
					
					break;
				case 2:
					ViewFollowers(visitingProfile.username);
					
					break;
				case 3:
					DisplayProfileLink(visitingProfile.username);
                    
					GoBack();
					
					break;
				case 0:
					
					break;
				default:
					Console.WriteLine("Please enter a valid input.");
					
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
			Console.WriteLine();
			
			Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }
    }
}