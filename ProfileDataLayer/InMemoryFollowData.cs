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
		followData.Add(new Follow{following = "rosejoy_balonzo", follower = "NelsonAbn"});
		followData.Add(new Follow{following = "itsme_kai", follower = "JB"});
		followData.Add(new Follow{following = "JB", follower = "itsme_kai"});
		followData.Add(new Follow{following = "Raf_7", follower = "Nìcs"});
		followData.Add(new Follow{following = "Nìcs", follower = "Raf_7"});
		followData.Add(new Follow{following = "kylaaki", follower = "Bentor"});
		followData.Add(new Follow{following = "Bentor", follower = "kylaaki"});
		followData.Add(new Follow{following = "Jaskuno", follower = "andreabalaba"});
		followData.Add(new Follow{following = "andreabalaba", follower = "Jaskuno"});
		followData.Add(new Follow{following = "Yityet07", follower = "Laica Erica"});
		followData.Add(new Follow{following = "Laica Erica", follower = "Yityet07"});
		followData.Add(new Follow{following = "andreilangtoguys", follower = "Nica_21"});
		followData.Add(new Follow{following = "Nica_21", follower = "andreilangtoguys"});
		followData.Add(new Follow{following = "JAC", follower = "sharie.crvn"});
		followData.Add(new Follow{following = "sharie.crvn", follower = "JAC"});
		followData.Add(new Follow{following = "Charles_A", follower = "minatamis"});
		followData.Add(new Follow{following = "minatamis", follower = "Charles_A"});
		followData.Add(new Follow{following = "rishingz", follower = "Jm Dinglasan"});
		followData.Add(new Follow{following = "Jm Dinglasan", follower = "rishingz"});
		followData.Add(new Follow{following = "Kyrue", follower = "hyunysss"});
		followData.Add(new Follow{following = "hyunysss", follower = "Kyrue"});
		followData.Add(new Follow{following = "encisohappy08", follower = "irwennn"});
		followData.Add(new Follow{following = "irwennn", follower = "encisohappy08"});
		followData.Add(new Follow{following = "Seanshine", follower = "Eyaann27"});
		followData.Add(new Follow{following = "Eyaann27", follower = "Seanshine"});
		followData.Add(new Follow{following = "Nolongerhakori ", follower = "Earth "});
		followData.Add(new Follow{following = "Earth ", follower = "Nolongerhakori "});
		followData.Add(new Follow{following = "Itschii", follower = "reginaflopezx"});
		followData.Add(new Follow{following = "reginaflopezx", follower = "Itschii"});
		followData.Add(new Follow{following = "salmafae0809", follower = "Watss"});
		followData.Add(new Follow{following = "Watss", follower = "salmafae0809"});
		followData.Add(new Follow{following = "Angel", follower = "knnth0220"});
		followData.Add(new Follow{following = "knnth0220", follower = "Angel"});
		followData.Add(new Follow{following = "chilikalbo", follower = "gjmp"});
		followData.Add(new Follow{following = "gjmp", follower = "chilikalbo"});
		followData.Add(new Follow{following = "Jemen0225", follower = "stphnprz09"});
		followData.Add(new Follow{following = "stphnprz09", follower = "Jemen0225"});
		followData.Add(new Follow{following = "@rzllmqtlg", follower = "Johnjan69"});
		followData.Add(new Follow{following = "Johnjan69", follower = "@rzllmqtlg"});
		followData.Add(new Follow{following = "Jimwell", follower = "paaats"});
		followData.Add(new Follow{following = "paaats", follower = "Jimwell"});
		followData.Add(new Follow{following = "WD_mstrJHNT", follower = "Vic"});
		followData.Add(new Follow{following = "Vic", follower = "WD_mstrJHNT"});
		followData.Add(new Follow{following = "einhaalliahgmuday", follower = "salmafae0809"});
	}
}
