using System;
using ProfileDataModels;

namespace ProfileDataLayer;

public class InMemoryRegistrationData
{
	private List<RegisteredAccount> registeredAccounts = new List<RegisteredAccount>();
	
	public List<RegisteredAccount> GetRegisteredAccounts()
	{
		return registeredAccounts;
	}
	
	public InMemoryRegistrationData()
	{
		CreateRegisteredAccounts();
	}
	
	public void CreateRegisteredAccount(string pstudentNo, string pusername) 
	{
		registeredAccounts.Add(new RegisteredAccount{studentNo = pstudentNo, username = pusername});
	}
	
	public void CreateRegisteredAccounts()
	{
		RegisteredAccount account2 = new RegisteredAccount 
		{
			studentNo = "2021-00214-BN-0",
			username = "einhaalliahgmuday"
		};
		
		registeredAccounts.Add(account2);
	}

}
