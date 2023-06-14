using System;
using ProfileBusinessRules;
using ProfileDataModels;

namespace Profile
{
	internal class Program
	{	
		public static ProfileRules profileRules = new ProfileRules();
		public static string username = "juandelacruz";
		public static ProfileAccount user = profileRules.GetProfileAccountByUsername(username);
		public static string profileUsername;
		public static int input;
		
		public static void Main(string[] args)
		{	
			ViewProfileMain();
		}
		
		static void ViewProfileMain()
        {	
			DisplayProfile(username);
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
            Console.WriteLine("1 | Edit Profile");
            Console.WriteLine("2 | View Timeline");
            Console.WriteLine("3 | Following");
            Console.WriteLine("4 | Followers");
            Console.WriteLine("5 | Add Post");
            Console.WriteLine("6 | Options");
            Console.WriteLine("-----------------");
            GetUserInput();
        }
		
        static void ProcessUserActionInMainMenu()
        {
            switch (input)
            {
                case 1:
					while (input != 0)
					{
						MakeSpace();
						ShowEditProfileMenu();
						
						MakeSpace();
						ProcessUserActionInEditProfileMenu();
					}
					
                    break;
                case 2:
					
					
					GoBack();
					ViewProfileMain();
				
                    break;
                case 3:
					while (input != 0)
					{
						MakeSpace();
						ViewFollowingList(user);
						
						MakeSpace();
						ShowViewFollowsMenu("Following");
					}
					
                    break;
                case 4:
					while (input != 0)
					{
						MakeSpace();
						ViewFollowersList(user);
						
						MakeSpace();
						ShowViewFollowsMenu("Followers");
					}
					
                    break;
                case 5:
				
				
					GoBack();
					ViewProfileMain();
					
                    break;
                case 6:
					while (input != 0)
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
					profileRules.EditProfileInformation(username, "Gender Pronouns", updatedInformation);
					
					break;
				case 2:
					updatedInformation = GetUpdatedInformation("Bio");
					profileRules.EditProfileInformation(username, "Bio", updatedInformation);
					
					break;
				}
		}
		
		static string GetUpdatedInformation(string information)
		{
			Console.Write("Enter updated {0}: ", information);
			string updatedInformation = Console.ReadLine();
			
			return updatedInformation;
		}
		
		static void ViewFollowingList(ProfileAccount account)	//string username
		{
			// ProfileAccount account = profileRules.GetProfileAccountByUsername(username);
			
			Console.WriteLine("FOLLOWING: ");
			Console.WriteLine();
			
			foreach (var follow in account.following)
			{
				Console.WriteLine("{0}   		{1}", follow.name, follow.username);
			}
		}
		
		static void ViewFollowersList(ProfileAccount account)	//string username
		{
			// ProfileAccount account = profileRules.GetProfileAccountByUsername(username);
			
			Console.WriteLine("FOLLOWERS: ");
			Console.WriteLine();
			
			foreach (var follow in account.followers)
			{
				Console.WriteLine("{0}   		{1}", follow.name, follow.username);
			}
		}
		
		static void ShowViewFollowsMenu(string inFollowingOrFollowers)
		{
			Console.WriteLine("---FOLLOW MENU---");
			Console.WriteLine("1 | Search");
			Console.WriteLine("2 | Visit Profile");
			Console.WriteLine("0 | Go back");
			Console.WriteLine("----------------");
			GetUserInput();
			
			MakeSpace();
			ProcessUserActionInViewFollowsMenu(inFollowingOrFollowers);
		}
		
		static void ProcessUserActionInViewFollowsMenu(string inFollowingOrFollowers)	//EDIT HERE
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
					
					List<ProfileAccount> searchedAccounts = new List<ProfileAccount>();
					
					if (inFollowingOrFollowers == "Following")
					{
						searchedAccounts = profileRules.Search(search, user.following);
					}
					else if (inFollowingOrFollowers == "Followers")
					{
						searchedAccounts = profileRules.Search(search, user.followers);
					}
					
					foreach (var account in searchedAccounts)
					{
						Console.WriteLine("{0}   		{1}", account.name, account.username);
					}
					
					GoBack();
					
					break;
				case 2:
					Console.Write("Enter profile username to visit: ");
					profileUsername = Console.ReadLine();
					MakeSpace();
					
					while (input != 0)
					{
						DisplayProfile(profileUsername);
						MakeSpace();
						ShowOthersProfileMenu();
						ProcessUserActionInOthersProfileMenu();
					}
					
					break;
			}
		}
		
		static void ShowOthersProfileMenu()
		{
			String followOption = profileRules.GenerateFollowOption(username, profileUsername);
			
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
		
		static void ProcessUserActionInOthersProfileMenu()
		{
			ProfileAccount visitingProfile = profileRules.GetProfileAccountByUsername(profileUsername);
			
			switch (input)
			{
				case 0:
					
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
						MakeSpace();
					
						if (profileRules.CanUserViewThisProfilesInformation(user, visitingProfile))
						{
							ViewFollowingList(visitingProfile);
						}
						
						MakeSpace();
						ShowViewFollowsMenu("Following");
					}
					
					break;
				case 4:
					while(input != 0)
					{
						MakeSpace();
					
						if (profileRules.CanUserViewThisProfilesInformation(user, visitingProfile))
						{
							ViewFollowersList(visitingProfile);
						}
						
						MakeSpace();
						ShowViewFollowsMenu("Following");
					}
					
					break;
				case 5:
					
					GoBack();
					
					break;
				case 6:
					MakeSpace();
					ShowVisitingProfileOptionMenu();
					MakeSpace();
					ProcessUserActionInVisitingProfileOptionsMenu();
					
					break;
			}
		}
		
		static void ShowVisitingProfileOptionMenu()
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
                    

                    break;
                case 1:
					string profileLink = profileRules.GenerateProfileLink(profileUsername);
					Console.WriteLine("This profile account's link: {1}", profileLink);
					
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
                    string profileLink = profileRules.GenerateProfileLink(username);
					Console.WriteLine("Your profile link: {0}", profileLink);
                    
					GoBack();
					
                    break;
                case 2:
                    
					
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