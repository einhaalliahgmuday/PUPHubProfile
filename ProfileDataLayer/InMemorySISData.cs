using ProfileDataModels;

namespace ProfileDataLayer;

public class InMemorySISData
{
	private List <SISAccount> sisAccounts = new List <SISAccount>();
	
	public List <SISAccount> GetSISAccounts()
	{
		return sisAccounts;
	}
	
	public InMemorySISData()
	{
		CreateSISAccounts();
	}
	
	public void CreateSISAccounts() 
	{
		sisAccounts.Add(new SISAccount{studentNo = "2021-00214-BN-0", name = "Einha Alliah G. Muday", courYrSec = "BSIT 2-1", location = "Ganado, Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00413-BN-0", name = "Nelson Abuan", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
	}
}
