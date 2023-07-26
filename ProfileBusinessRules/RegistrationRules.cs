using ProfileDataLayer;
using ProfileDataModels;

namespace ProfileBusinessRules
{
    public class RegistrationRules
    {
        
        ProfileDataService dataService = new ProfileDataService();
		// InMemoryRegistrationData registrationData = new InMemoryRegistrationData();
		ProfileRules profileRules = new ProfileRules();

        public List<RegisteredAccount> GetAllRegisteredAccounts()
		{
			return dataService.GetAllTheRegisteredAccounts();
		}
		
		public RegisteredAccount GetRegisteredAccountByStudentNo(string studentNo)
		{
			var allRegisteredAccounts = GetAllRegisteredAccounts();
			var foundAccount = new RegisteredAccount();
			
			foreach (var account in allRegisteredAccounts)
			{
				if (studentNo == account.studentNo)
				{
					foundAccount = account;
				}
			}
			
			return foundAccount;
		}
		
		public void CreateAccount(string pstudentNo, string pusername, string pgenderPronouns, string pbio)
		{
			ProfileAccount profile = new ProfileAccount {
				username = pusername,
				genderPronouns = pgenderPronouns,
				rating = "0",
				dateJoined = DateTime.Now,
				bio = pbio
			};
		
			RegisteredAccount registered = new RegisteredAccount {
				studentNo = pstudentNo,
				username = pusername
			};
		
			dataService.CreateTheProfileAccount(profile);
			dataService.RegisterTheAccount(registered);
		}
	
		public void CreateAccount(string pstudentNo, string pusername)
		{
			ProfileAccount profileAccount = new ProfileAccount{
				username = pusername,
				genderPronouns = "",
				rating = "0",
				dateJoined = DateTime.Now,
				bio = ""

			};
			
			RegisteredAccount registeredAccount = new RegisteredAccount{
				studentNo = pstudentNo,
				username = pusername
			};
			
			dataService.CreateTheProfileAccount(profileAccount);
			dataService.RegisterTheAccount(registeredAccount);
		}
	
		public void DeleteAccount(string studentNo)
		{
			var registeredAccount = GetRegisteredAccountByStudentNo(studentNo);
			var profileAccount = profileRules.GetProfileAccountByUsername(registeredAccount.username);
		   
			if (registeredAccount != null && profileAccount != null)
			{
				dataService.DeleteTheRegisteredAccount(registeredAccount);
				dataService.DeleteTheProfileAccount(profileAccount);
			}
		}

        public bool IsUsernameExists(string username)
        {
            bool doesUsernameAlreadyExists = false;
            var allRegisteredAccounts = GetAllRegisteredAccounts();

            foreach (var account in allRegisteredAccounts)
            {
                if (account.username == username)
                {
                    doesUsernameAlreadyExists = true;
					break;
                }
            }

            return doesUsernameAlreadyExists;
        }

        public bool IsAccountRegistered(string studentNo)
        {
            bool isAccountRegistered = false;
            var allRegisteredAccounts = GetAllRegisteredAccounts();

            foreach (var account in allRegisteredAccounts)
            {
                if (account.studentNo == studentNo)
                {
                    isAccountRegistered = true;
					break;
                }
            }

            return isAccountRegistered;
        }


    }
}
