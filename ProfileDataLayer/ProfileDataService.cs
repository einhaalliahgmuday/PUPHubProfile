using System.Collections.Generic;
using ProfileDataModels;

namespace ProfileDataLayer;

public class ProfileDataService
{
	SqlData sqlData = new SqlData();
	
	public List<RegisteredAccount> GetAllTheRegisteredAccounts()
	{
		return sqlData.GetRegisteredAccounts();
	}
	
	public void RegisterTheAccount(RegisteredAccount registeredAccount) 
	{
		sqlData.RegisterAccount(registeredAccount);
	}
	
	public void DeleteTheRegisteredAccount(RegisteredAccount registeredAccount) 
	{
		sqlData.DeleteRegisteredAccount(registeredAccount);
	}
		
	
	public List<ProfileAccount> GetAllTheProfileAccounts()
	{
		return sqlData.GetProfileAccounts();
	}
	
	public void CreateTheProfileAccount(ProfileAccount profileAccount) 
	{
		sqlData.CreateProfileAccount(profileAccount);
	}
	
	public void UpdateTheProfileAccount(ProfileAccount profileAccount, string informationToUpdate, string updatedInformation)
	{
		sqlData.UpdateProfileAccount(profileAccount, informationToUpdate, updatedInformation);
	}
	
	public void DeleteTheProfileAccount(ProfileAccount profileAccount) 
	{
		sqlData.DeleteProfileAccount(profileAccount);
	}
	
}
