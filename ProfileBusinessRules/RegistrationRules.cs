﻿using ProfileDataLayer;
using ProfileDataModels;

namespace ProfileBusinessRules
{
    public class RegistrationRules
    {
        
        ProfileDataService dataService = new ProfileDataService();
		ProfileRules profileRules = new ProfileRules();
		InMemorySISData sisData = new InMemorySISData();
		
		public bool IsStudentExists(string studentNo)
		{
			bool IsAccountExists = false;
			var allSISAccounts = sisData.GetSISAccounts();
			
			foreach (var account in allSISAccounts) 
			{
				if (account.studentNo == studentNo)
				{
					IsAccountExists = true;
					break;
				}
			}
			
			return IsAccountExists;
		}

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
				if (account.studentNo == studentNo)
				{
					foundAccount = account;
				}
			}
			
			return foundAccount;
		}
		
		public RegisteredAccount GetRegisteredAccountByUsername(string username)
		{
			var allRegisteredAccounts = GetAllRegisteredAccounts();
			var foundAccount = new RegisteredAccount();
			
			foreach (var account in allRegisteredAccounts)
			{
				if (account.username == username)
				{
					foundAccount = account;
				}
			}
			
			return foundAccount;
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
    }
}
