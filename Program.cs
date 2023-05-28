using System;
using ProfileBusinessRules;
using ProfileDataModels;

namespace Profile
{
	internal class Program
	{
		public static int input;
<<<<<<< Updated upstream
=======
		public static string username = "juandelacruz";
		public static string updatedInformation;
		
		public static ProfileRules profile = new ProfileRules();
>>>>>>> Stashed changes
		
		static void Main(string[] args)
		{
			ViewProfileMain();
		}
		
		static void ViewProfileMain()
<<<<<<< Updated upstream
        {
			ProfileRules.ViewProfileInformation();
=======
        {	
			DisplayProfile(username);	
>>>>>>> Stashed changes
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

			Console.WriteLine();
			Console.WriteLine();
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
					ShowEditProfileMenu();
					
                    break;
                case 2:
					
					
					GoBack();
					ViewProfileMain();
				
                    break;
                case 3:
					ProfileRules.ViewFollowing();
					
					Console.WriteLine();
					Console.WriteLine();
					
					GoBack();
					ViewProfileMain();
					
                    break;
                case 4:
					ProfileRules.ViewFollowers();
					
					Console.WriteLine();
					Console.WriteLine();
					
					GoBack();
					ViewProfileMain();
					
                    break;
                case 5:
				
				
					GoBack();
					ViewProfileMain();
					
                    break;
                case 6:
                    ShowOptionsMenu();

                    break;
            }
        }
		
		static void ShowOptionsMenu()
        {
			while (input != 0)
			{
				Console.WriteLine("-------OPTIONS-------");
				Console.WriteLine("1 | View profile link");
				Console.WriteLine("2 | Settings");
				Console.WriteLine("0 | Go back");
				Console.WriteLine("---------------------");
				GetUserInput();

				ProcessUserActionInOptionsMenu();
			}
        }

        static void ProcessUserActionInOptionsMenu()
        {
            switch (input)
            {
                case 0:
                    ViewProfileMain();

                    break;
                case 1:
<<<<<<< Updated upstream
                    ProfileRules.GenerateProfileLink();
=======
                    string profileLink = profile.GenerateProfileLink(username);
					Console.WriteLine("Your profile link: {0}", profileLink);
					
					Console.WriteLine();
>>>>>>> Stashed changes
                    
					GoBack();
                    ShowOptionsMenu();
					
                    break;
                case 2:
                    
					
					GoBack();
                    ShowOptionsMenu();

                    break;
            }
        }
		
		static void ShowEditProfileMenu()
		{
			while (input != 0) 
			{
				Console.WriteLine("----EDIT PROFILE----");
				Console.WriteLine("1 | Edit Name");
				Console.WriteLine("2 | Edit Username");
				Console.WriteLine("3 | Edit Gender Pronouns");
				Console.WriteLine("4 | Edit Bio");
				Console.WriteLine("5 | Edit Course Year & Section");
				Console.WriteLine("6 | Edit Location");
				Console.WriteLine("0 | Go back");
				Console.WriteLine("--------------------");
				GetUserInput();
				
				ProcessUserActionInEditProfileMenu();
				
				Console.WriteLine();
				Console.WriteLine();
			}
		}
		
		static void ProcessUserActionInEditProfileMenu()
		{
				switch (input)
				{
					case 0:
						ViewProfileMain();
						
						break;
<<<<<<< Updated upstream
                    case 1:
                        ProfileRules.UpdateProfile("Name");

                        break;
                    case 2:
						ProfileRules.UpdateProfile("Username");
						
						break;
					case 3:
						ProfileRules.UpdateProfile("Gender Pronouns");
=======
					case 1:
						updatedInformation = GetUpdatedInformation("Gender Pronouns");
						profile.EditProfileInformation(username, "Gender Pronouns", updatedInformation);
						
						break;
					case 2:
						updatedInformation = GetUpdatedInformation("Bio");
						profile.EditProfileInformation(username, "Bio", updatedInformation);
>>>>>>> Stashed changes
						
						break;
					case 4:
						ProfileRules.UpdateProfile("Bio");
						
						break;
					case 5:
						ProfileRules.UpdateProfile("Course, Year & Section");
						
						break;
					case 6:
						ProfileRules.UpdateProfile("Location");
					
						break;
				}
		}
		
<<<<<<< Updated upstream
=======
		static string GetUpdatedInformation(string information)
		{
			Console.Write("Enter updated {0}: ", information);
			updatedInformation = Console.ReadLine();
			
			return updatedInformation;
		}
		
		static void ViewFollowing()
		{
			profile.DisplayFollowingList(username);
			ShowViewFollowsMenu();
		}
		
		static void ViewFollowers()
		{
			profile.DisplayFollowersList(username);
			ShowViewFollowsMenu();
		}
		
		static void ShowViewFollowsMenu()
		{
			while (input != 0) 
			{
				Console.WriteLine("--FOLLOW MENU---");
				Console.WriteLine("1 | Search");
				Console.WriteLine("0 | Go back");
				Console.WriteLine("----------------");
				GetUserInput();
				
				ProcessUserActionInFollowsMenu();
				
				Console.WriteLine();
				Console.WriteLine();
			}
		}
		
		static void ProcessUserActionInFollowsMenu()
		{
			switch (input)
			{
				case 0:
					ViewProfileMain();
					
					break;
				case 1:
					Console.Write("Enter profile username to view: ");
					string profileUsername = Console.ReadLine();
					
					Console.WriteLine();
					Console.WriteLine();
					
					DisplayProfile(profileUsername);
					
					GoBack();
					// ShowViewFollowsMenu();
					
					break;
			}
		}
		
>>>>>>> Stashed changes
		static int GetUserInput()
        {
            Console.Write("Your input: ");
            input = Convert.ToInt32(Console.ReadLine());
			
			Console.WriteLine();
			Console.WriteLine();

            return input;
        }

        static void GoBack()
        {
			Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
			
			Console.WriteLine();
			Console.WriteLine();
        }
		
    }
}