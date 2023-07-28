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
		sisAccounts.Add(new SISAccount{studentNo = "2021-00067-BN-0", name = "Sarah Michelle Orejo", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00217-BN-0", name = "Mekaila Aguila", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00417-BN-0", name = "Jaby Almadin", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00416-BN-0", name = "Rafael Luis Amoranto", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00215-BN-0", name = "Nico Ampoloquio", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00062-BN-0", name = "Kyla Kurstien Aquino", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00223-BN-0", name = "Victor Troy J. Avila", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00404-BN-0", name = "Jaspher D. Baet", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00490-BN-0", name = "Andrea R. Balaba", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00058-BN-0", name = "Rose Joy Balonzo", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00200-BN-0", name = "Claris Batacandolo", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00341-BN-0", name = "Lilac Erica Begino", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00216-BN-0", name = "Andrei Edoyaga Bodota", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00155-BN-0", name = "Danica Mae D. Cabrera", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00157-BN-0", name = "John Aldrich Calabio", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00397-BN-0", name = "Charie Caravana", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00158-BN-0", name = "Charles Aaron Cayabyab", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00057-BN-0", name = "Jemuel De Sagun Cebuano", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00059-BN-0", name = "Justine Irish Diolata", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00065-BN-0", name = "John Mari Dinglasan", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00074-BN-0", name = "Euryk Matthew C. Dy", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00064-BN-0", name = "Eunice Stephanie Emata", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00428-BN-0", name = "Happy Enciso", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00489-BN-0", name = "Erwin Esparto", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00199-BN-0", name = "Sean Paula Estayan", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00156-BN-0", name = "Lorrea Ann Hugo", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00211-BN-0", name = "Laurence Lagado", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00152-BN-0", name = "Earth Jeune B. Layola", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00212-BN-0", name = "Michi Legaspino", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00268-BN-0", name = "Regina Felix Lopez", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00159-BN-0", name = "Salma Fae A. Lumaoang", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00418-BN-0", name = "Clarestter Dhuke Marquez", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00182-BN-0", name = "Alliah Angel L. Nacor", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00347-BN-0", name = "Kenneth N. Odgien", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00188-BN-0", name = "Catherine Lorraine Odon", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00412-BN-0", name = "Genesis Jamaica Panganiban", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00515-BN-0", name = "Jemen Van Ladera Pastor", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00066-BN-0", name = "Stephen Mathew C. Perez", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00408-BN-0", name = "Razell Mae P. Quitalig", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00063-BN-0", name = "John Isaac Rizon", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00154-BN-0", name = "Jimwell L. Rosario", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00061-BN-0", name = "Patricia Laine Sison", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00224-BN-0", name = "John Henry Torres", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00266-BN-0", name = "Joanvic Vargas", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
		sisAccounts.Add(new SISAccount{studentNo = "2021-00346-BN-0", name = "Danica Malana", courYrSec = "BSIT 2-1", location = "Binan City, Laguna"});
	}
}
