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
		
		public RegisteredAccount GetRegisteredAccountByUsername(string username)
		{
			var allRegisteredAccounts = GetAllRegisteredAccounts();
			var foundAccount = new RegisteredAccount();
			
			foreach (var account in allRegisteredAccounts)
			{
				if (username == account.username)
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
	
		public void DeleteAccount(string username)
		{
			var registeredAccount = GetRegisteredAccountByUsername(username);
			var profileAccount = profileRules.GetProfileAccountByUsername(username);
		   
			if (registeredAccount != null && profileAccount != null)
			{
				dataService.DeleteTheRegisteredAccount(registeredAccount);
				dataService.DeleteTheProfileAccount(profileAccount);
			}
		}

        public bool DoesUsernameAlreadyExists(string username)
        {
            bool doesUsernameAlreadyExists = false;
            var allRegisteredAccounts = GetAllRegisteredAccounts();

            foreach (var account in allRegisteredAccounts)
            {
                if (account.username == username)
                {
                    doesUsernameAlreadyExists = true;
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
                }
            }

            return isAccountRegistered;
        }


    }
}
