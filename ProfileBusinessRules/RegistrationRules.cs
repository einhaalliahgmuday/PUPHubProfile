using System;
using ProfileDataLayer;
using ProfileDataModels;

namespace ProfileBusinessRules;

public class RegistrationRules
{
	InMemoryRegistrationData registrationData = new InMemoryRegistrationData();
	
	public List<RegisteredAccount> GetAllRegisteredAccounts()
	{
		return registrationData.GetRegisteredAccounts();
	}
	
	// DoesStudentExists in AllSISAccounts
	
	public bool DoesUsernameAlreadyExists(string username)
	{
		bool doesUsernameAlreadyExists = false;
		var allRegisteredAccounts = GetAllRegisteredAccounts();
		
		foreach (var account in allRegisteredAccounts) {
			if (account.username == username)
			{
				doesUsernameAlreadyExists = true;
			}
		}
		
		return doesUsernameAlreadyExists;
	}
	
	public void CreateProfileAccount()
	{
		//SIS Account information
	}
	
	public void RegisterProfileAccount()
	{
		//dateJoined as registered
		//add profile to all accounts
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
	
	
	//Models: username, studentNo
	//username, genderPronouns, dateJoined, bio, 	accountPrivacy
	
	//infos from SIS account: name (firstName, middleName, lastName), courYrSec, location
	//following and followers

}
