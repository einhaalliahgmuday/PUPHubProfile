namespace ProfileDataModels;

public class ProfileAccount
{
    public string name {get; set;}
    public string username {get; set;}
	public string genderPronouns {get; set;}
	public string rating {get; set;}
	public string bio {get; set;}
	public string courYrSec {get; set;}
	public string location {get; set;}
	
	public List <ProfileAccount> followers = new List <ProfileAccount>();
	public List <ProfileAccount> following = new List <ProfileAccount>();
}
