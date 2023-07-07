using System.Collections.Generic;
using ProfileDataModels;

namespace ProfileDataLayer;

public class ProfileDataService
{
	SqlData sqlData = new SqlData();
	
	public List<RegisteredAccount> GetAllRegisteredAccounts()
	{
		return sqlData.GetRegisteredAccounts();
	}
	
	public void RegisterAccount(RegisteredAccount registeredAccount) 
	{
		sqlData.RegisterAccount(registeredAccount);
	}
	
	public List<ProfileAccount> GetAllTheProfileAccounts()		//change naming convention
	{
		return sqlData.GetProfileAccounts();
	}
	
	public void CreateProfileAccount(ProfileAccount profileAccount) 
	{
		sqlData.CreateProfileAccount(profileAccount);
	}
	
	public void UpdateTheProfileAccount(ProfileAccount profileAccount, string informationToUpdate, string updatedInformation)		//change naming convention
	{
		sqlData.UpdateProfileAccount(profileAccount, informationToUpdate, updatedInformation);
	}
	
}
