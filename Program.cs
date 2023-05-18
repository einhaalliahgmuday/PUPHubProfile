using System;
using ProfileBusinessRules;

namespace Profile
{
	internal class Program
	{	
		public static int input;
		
		public static void Main(string[] args)
		{	
			ViewProfileMain();
		}
		
		static void ViewProfileMain()
        {	
			//ProfileRules.ViewProfileInformation();
			ProfileRules prof = new ProfileRules();
			prof.DisplayProfile();
			
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
                    ProfileRules.GenerateProfileLink();
                    
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
                    case 1:
                        ProfileRules.UpdateProfile("Name");

                        break;
                    case 2:
						ProfileRules.UpdateProfile("Username");
						
						break;
					case 3:
						ProfileRules.UpdateProfile("Gender Pronouns");
						
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