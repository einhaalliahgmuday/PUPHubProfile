namespace DataLayer;

public class ProfileAccount
{
    public string name {get; set;}
    public string username {get; set;}
	public string genderPronouns {get; set;}
	public string rating {get; set;}
	public string bio {get; set;}
	public string courYrSec {get; set;}
	public string location {get; set;}

    public FollowData follows { get; set; } = new FollowData();
}
public class FollowData
{
    public List<ProfileAccount> followers = new List<ProfileAccount>();
    public List<ProfileAccount> following = new List<ProfileAccount>();
}

    

