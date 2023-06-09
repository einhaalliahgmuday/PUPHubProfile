using ProfileDataModels;

namespace ProfileDataLayer;

public class InMemoryProfileAccountsFollowData
{
	InMemoryProfileData profileData = new InMemoryProfileData();
	
	public InMemoryProfileAccountsFollowData()
	{
		SetProfileFollowers();
		SetProfileFollowing();
	}
	
	// public List<ProfileAccount> GetAllProfileAccounts()
	// {
			// return profileData.GetProfileAccounts();
	// }
	
	public void SetProfileFollowers()
	{
		List<ProfileAccount> allProfileAccounts = profileData.GetProfileAccounts();
		ProfileAccount user = allProfileAccounts[0];
		ProfileAccount profile2 = allProfileAccounts[1];
		ProfileAccount profile3 = allProfileAccounts[2];
		ProfileAccount profile4 = allProfileAccounts[3];
		ProfileAccount profile5 = allProfileAccounts[4];
		ProfileAccount profile6 = allProfileAccounts[5];
		
		user.followers.Add(profile2);
		user.followers.Add(profile3);
		user.followers.Add(profile4);
		user.followers.Add(profile5);
		user.followers.Add(profile6);
	}
	
	public void SetProfileFollowing()
	{
		// user.following.Add(profile2);
		// user.following.Add(profile4);
		// user.following.Add(profile5);
		// user.following.Add(profile6);
	}
	
	
	
	// public void SetFollowingAndFollowers ()
    // {
      // ProfileAccount user = InMemoryProfileData.profileAccounts[0];
      // ProfileAccount profile2 = InMemoryProfileData.profileAccounts[1];
      // ProfileAccount profile3 = InMemoryProfileData.profileAccounts[2];
      // ProfileAccount profile4 = InMemoryProfileData.profileAccounts[3];
      // ProfileAccount profile5 = InMemoryProfileData.profileAccounts[4];
      // ProfileAccount profile6 = InMemoryProfileData.profileAccounts[5];

      // //user Following
      // user.follows.following.Add (profile3);
      // user.follows.following.Add (profile5);
      // user.follows.following.Add (profile2);
      // user.follows.following.Add (profile6);

      // //user Followers
      // user.follows.followers.Add (profile2);
      // user.follows.followers.Add (profile3);
      // user.follows.followers.Add (profile4);
      // user.follows.followers.Add (profile5);
      // user.follows.followers.Add (profile6);

      // //profile2 Following    
      // profile2.follows.following.Add (user);
      // profile2.follows.following.Add (profile4);
      // profile2.follows.following.Add (profile3);
      // profile2.follows.following.Add (profile6);

      // //profile2 Followers  
      // profile2.follows.followers.Add (user);
      // profile2.follows.followers.Add (profile4);
      // profile2.follows.followers.Add (profile6);
      // profile2.follows.followers.Add (profile5);

      // //profile3 Following   
      // profile3.follows.following.Add (user);
      // profile3.follows.following.Add (profile2);
      // profile3.follows.following.Add (profile4);
      // profile3.follows.following.Add (profile5);

      // //profile3 Followers   
      // profile3.follows.followers.Add (user);
      // profile3.follows.followers.Add (profile2);


      // //profile4 Following
      // profile4.follows.following.Add (user);
      // profile4.follows.following.Add (profile2);

      // //profile4 Follower
      // profile4.follows.followers.Add (profile2);
      // profile4.follows.followers.Add (profile3);
      // profile4.follows.followers.Add (profile6);


      // //profile5 Following
      // profile5.follows.following.Add (user);
      // profile5.follows.following.Add (profile2);

      // //profile5 Followers 
      // profile5.follows.followers.Add (user);
      // profile5.follows.followers.Add (profile3);


      // //profile6 Following
      // profile6.follows.following.Add (user);
      // profile6.follows.following.Add (profile2);
      // profile6.follows.following.Add (profile4);

      // //profile6 Followers
      // profile6.follows.followers.Add (user);
      // profile6.follows.followers.Add (profile2);
    // }
}
