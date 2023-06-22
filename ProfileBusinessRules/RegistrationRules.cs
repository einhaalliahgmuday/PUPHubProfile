namespace ProfileBusinessRules;

public class RegistrationRules
{
	// DoesStudentExists in AllSISAccounts
	
	public void bool DoesUsernameAlreadyExists()
	{
		// set username, if true (but isn't the username automatically generated, kasi dapat unique? o dapat si user maglalagay, tas may validation if it already exists?)
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
	
	public void IsAccountRegistered()
	{
		// Search from all accounts		validation if the student has profile account, otherwise they need to register first
		//through studentNo
	}
	
	
	//Models: username, studentNo
	//username, genderPronouns, dateJoined, bio, 	accountPrivacy
	
	//infos from SIS account: name (firstName, middleName, lastName), courYrSec, location
	//following and followers

}
