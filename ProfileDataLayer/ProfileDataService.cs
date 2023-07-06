using System.Collections.Generic;
using ProfileDataModels;

namespace ProfileDataLayer;

public class ProfileDataService
{
	SqlData sqlData = new SqlData();
	
	public List<RegisteredAccount> GetAllRegisteredAccounts
	{
		return sqlData.GetRegisteredAccounts;
	}
	
	public void RegisterAccount(RegisteredAccount registeredAccount) 
	{
		sqlData.RegisterAccount(registeredAccount);
	}
	
	public List<ProfileAccount> GetAllProfileAccounts
	{
		return sqlData.GetProfileAccounts;
	}
	
	public void CreateProfileAccount(ProfileAccount profileAccount) 
	{
		sqlData.CreateProfileAccount(profileAccount);
	}
	
	public void UpdateProfileAccount(string informationToUpdate, ProfileAccount profileAccount)
	{
		sqlData.UpdateProfileAccount(informationToUpdate, profileAccount);
	}
	
}
