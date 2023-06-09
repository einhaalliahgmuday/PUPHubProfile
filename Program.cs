using System;
using ProfileBusinessRules;
using ProfileDataModels;

namespace Profile
{
	internal class Program
	{	
		public static int input;
		public static string updatedInformation;
		public static string username = "juandelacruz";
		public static ProfileRules profile = new ProfileRules();
		
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
			ProfileAccount account = profile.GetProfileAccountByUsername(username);
			
			Console.WriteLine("{0}	{1}", account.name, account.genderPronouns);
			Console.WriteLine(account.username);
			Console.WriteLine(account.rating);

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
						ViewFollowingList(username);
						
						MakeSpace();
						ShowViewFollowsMenu();
						
						MakeSpace();
						ProcessUserActionInViewFollowsMenu();
					}
					
                    break;
                case 4:
					while (input != 0)
					{
						MakeSpace();
						ViewFollowersList(username);
						
						MakeSpace();
						ShowViewFollowsMenu();
						
						MakeSpace();
						ProcessUserActionInViewFollowsMenu();
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
				switch (input)
				{
					case 0:
						ViewProfileMain();
						
						break;
					case 1:
						updatedInformation = GetUpdatedInformation("Gender Pronouns");
						profile.EditProfileInformation(username, "Gender Pronouns", updatedInformation);
						
						break;
					case 2:
						updatedInformation = GetUpdatedInformation("Bio");
						profile.EditProfileInformation(username, "Bio", updatedInformation);
						
						break;
				}
		}
		
		static string GetUpdatedInformation(string information)
		{
			Console.Write("Enter updated {0}: ", information);
			updatedInformation = Console.ReadLine();
			
			return updatedInformation;
		}
		
		static void ViewFollowingList(string username)
		{
			ProfileAccount account = profile.GetProfileAccountByUsername(username);
			
			Console.WriteLine("FOLLOWING: ");
			Console.WriteLine();
			
			foreach (var follow in account.following)
			{
				Console.WriteLine("{0}   		{1}", follow.name, follow.username);
			}
		}
		
		static void ViewFollowersList(string username)
		{
			ProfileAccount account = profile.GetProfileAccountByUsername(username);
			
			Console.WriteLine("FOLLOWERS: ");
			Console.WriteLine();
			
			foreach (var follow in account.followers)
			{
				Console.WriteLine("{0}   		{1}", follow.name, follow.username);
			}
		}
		
		static void ShowViewFollowsMenu()
		{
			Console.WriteLine("--FOLLOW MENU---");
			Console.WriteLine("1 | Search");
			Console.WriteLine("2 | Visit Profile");
			Console.WriteLine("0 | Go back");
			Console.WriteLine("----------------");
			GetUserInput();
		}
		
		static void ProcessUserActionInViewFollowsMenu()
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
					
					var allProfileAccounts = profile.GetAllProfileAccounts();
					
					foreach (var account in allProfileAccounts)
					{
						if (account.username.Contains(search)) 
						{
							Console.WriteLine("{0}   		{1}", account.name, account.username);
						}
					}
					
					GoBack();
					
					break;
				case 2:
					Console.Write("Enter profile username to visit: ");
					string profileUsername = Console.ReadLine();
					
					MakeSpace();
					DisplayProfile(profileUsername);
					
					MakeSpace();
					ShowViewOthersProfileMenu(profileUsername);
					
					GoBack();
					
					break;
			}
		}
		
		static void ShowViewOthersProfileMenu(string profileUsername)
		{
			FollowStatus followStatus = profile.CheckFollowStatus(username, profileUsername); 
			
			switch (followStatus)
			{
				case FollowStatus.Following:
					Console.WriteLine("-------MENU-------");
					Console.WriteLine("1 | Unfollow");
					Console.WriteLine("2 | Message");
					Console.WriteLine("3 | View Timeline");
					Console.WriteLine("4 | Options");
					Console.WriteLine("0 | Go Back");
					Console.WriteLine("------------------");
					GetUserInput();
					
					break;
				case FollowStatus.NotFollowing:
					Console.WriteLine("-----MENU-----");
					Console.WriteLine("1 | Follow");
					Console.WriteLine("2 | Message");
					Console.WriteLine("3 | View Timeline");
					Console.WriteLine("4 | Options");
					Console.WriteLine("0 | Go Back");
					Console.WriteLine("------------------");
					GetUserInput();
					
					break;
			}
		}
		
		static void ProcessUserActionInViewOthersProfileMenu()
		{
			switch (input)
			{
				case 0:
					
					
					break;
				case 1:
					
					
					break;
				case 2:
					
					
					break;
				case 3:
					
					
					break;
				case 4:
					
					
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
                    string profileLink = profile.GenerateProfileLink(username);
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