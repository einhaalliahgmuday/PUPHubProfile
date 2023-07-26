using ProfileDataModels;

namespace ProfileDataLayer;

public class InMemoryFollowData
{
	private List <Follow> followData = new List <Follow>();
	
	public List <Follow> GetFollowData()
	{
		return followData;
	}
	
	public InMemoryFollowData()
	{
		CreateFollowData();
	}
	
	public void CreateFollowData() 
	{
		followData.Add(new Follow{following = "NelsonAbn", follower = "rosejoy_balonzo"});
	}
}
