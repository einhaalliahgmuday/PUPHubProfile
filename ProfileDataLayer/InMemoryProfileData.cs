using System;
using ProfileDataModels;

namespace ProfileDataLayer;

public class InMemoryProfileData
{
	private List <ProfileAccount> profileAccounts = new List <ProfileAccount>();
	
	public List <ProfileAccount> GetProfileAccounts()
	{
		return profileAccounts;
	}
	
	public InMemoryProfileData()
	{
		CreateProfileAccounts();
	}
	
	public void CreateProfileAccounts() 
	{
		ProfileAccount user = new ProfileAccount
		{
			name = "Juan Dela Cruz",
			username = "juandelacruz",
			genderPronouns = "he/him",
			rating = "5.0 *****",
			dateJoined = new DateTime(2023, 5, 26),
			bio = "Nothing lasts forever, we can change the future.	- Alucard",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna",
			accountPrivacy = AccountPrivacy.Public
		};
		
		ProfileAccount profile2 = new ProfileAccount
		{
			name = "Einha Alliah Muday",
			username = "einhaalliahgmuday",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			dateJoined = new DateTime(2023, 6, 9),
			bio = "Live well.",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna",
			accountPrivacy = AccountPrivacy.Private
		};
		
		ProfileAccount profile3 = new ProfileAccount
		{
			name = "Danica Malana",
			username = "BSIT2-1_DanicaMalana",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			dateJoined = new DateTime(2023, 5, 26),
			bio = "227",
			courYrSec = "BSIT 2-1",
			location = "Cabuyao City, Laguna",
			accountPrivacy = AccountPrivacy.Public
		};
		
		ProfileAccount profile4 = new ProfileAccount
		{
			name = "Sarah Michelle Orejo",
			username = "BSIT2-1_SarahMichelleOrejo",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			dateJoined = new DateTime(2023, 5, 26),
			bio = "Sarah",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna",
			accountPrivacy = AccountPrivacy.Public
		};
		
		ProfileAccount profile5 = new ProfileAccount
		{
			name = "Andrea Balaba",
			username = "BSIT2-1_AndreaBalaba",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			dateJoined = new DateTime(2023, 5, 26),
			bio = "cute",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna",
			accountPrivacy = AccountPrivacy.Public
		};
		
		ProfileAccount profile6 = new ProfileAccount
		{
			name = "Razell Mae Quitalig",
			username = "_RazellMaeQuitalig",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			dateJoined = new DateTime(2023, 5, 26),
			bio = "rzllq",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna",
			accountPrivacy = AccountPrivacy.Public
		};
		
		profileAccounts.Add(user);
		profileAccounts.Add(profile2);
		profileAccounts.Add(profile3);
		profileAccounts.Add(profile4);
		profileAccounts.Add(profile5);
		profileAccounts.Add(profile6);
		
		user.following.Add(profile3);
		user.following.Add(profile5);
		user.following.Add(profile2);
		user.following.Add(profile6);

		user.followers.Add(profile2);
		user.followers.Add(profile3);
		user.followers.Add(profile4);
		user.followers.Add(profile5);
		user.followers.Add(profile6);
		
		profile2.following.Add(profile3);
		profile2.following.Add(profile5);
		profile2.following.Add(profile6);

		profile2.followers.Add(profile3);
		profile2.followers.Add(profile4);
		profile2.followers.Add(profile5);
		profile2.followers.Add(profile6);
		
		profile3.following.Add(profile5);
		profile3.following.Add(profile2);

		profile3.followers.Add(profile2);
		profile3.followers.Add(profile4);
		profile3.followers.Add(profile5);
		profile3.followers.Add(profile6);
		
		profile4.following.Add(profile3);
		profile4.following.Add(profile5);
		profile4.following.Add(profile2);
		profile4.following.Add(profile6);

		profile4.followers.Add(profile2);
		profile4.followers.Add(profile3);
		profile4.followers.Add(profile5);
		profile4.followers.Add(profile6);
		
		profile5.following.Add(profile3);
		profile5.following.Add(profile2);
		profile5.following.Add(profile6);

		profile5.followers.Add(profile2);
		profile5.followers.Add(profile3);
		profile5.followers.Add(profile6);
		
		profile6.following.Add(profile3);
		profile6.following.Add(profile5);
		profile6.following.Add(profile2);

		profile6.followers.Add(profile2);
		profile6.followers.Add(profile3);
		profile6.followers.Add(profile4);
		profile6.followers.Add(profile5);
	}
}
