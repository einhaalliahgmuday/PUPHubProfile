using System;
using ProfileBusinessRules;

namespace Profile
{
	internal class Program
	{	
		public static int input;
		public static string username = "juandelacruz";
		public static ProfileRules profile = new ProfileRules();
		
		public static void Main(string[] args)
		{	
			ViewProfileMain();
		}
		
		static void ViewProfileMain()
        {	
			profile.DisplayProfile(username);	
            ShowMainMenu();
            ProcessUserActionInMainMenu();
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
					ViewFollowing();
					
                    break;
                case 4:
					ViewFollowers();
					
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
                    profile.GenerateProfileLink(username);
                    
					GoBack();
					
                    break;
                case 2:
                    
					
					GoBack();

                    break;
            }
        }
		
		static void ShowEditProfileMenu()
		{
			while (input != 0) 
			{
				Console.WriteLine("----EDIT PROFILE----");
				Console.WriteLine("1 | Edit Gender Pronouns");
				Console.WriteLine("2 | Edit Bio");
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
					case 1:
						profile.EditProfileInformation("Gender Pronouns", username);
						
						break;
					case 2:
						profile.EditProfileInformation("Bio", username);
						
						break;
				}
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
					
					profile.DisplayProfile(profileUsername);
					
					GoBack();
					// ShowViewFollowsMenu();
					
					break;
			}
		}
		
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