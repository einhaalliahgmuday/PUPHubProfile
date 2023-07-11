using ProfileDataLayer;
using ProfileDataModels;

namespace ProfileBusinessRules
{
    public class RegistrationRules
    {
        
        ProfileDataService profileDataService = new ProfileDataService(); // Instantiate ProfileDataService

        public List<RegisteredAccount> GetAllRegisteredAccounts()
    {
    return profileDataService.GetAllRegisteredAccounts();
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

        public void RegisterProfileAccount(string studentNo, string username, string name, string courYrSec, string location)
        {
            registrationData.CreateRegisteredAccount(studentNo, username);
            profileData.CreateProfileAccount(name, username, courYrSec, location);
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
