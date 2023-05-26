﻿namespace DataLayer;

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
			bio = "Nothing lasts forever, we can change the future.	- Alucard",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna"
		};
		
		ProfileAccount profile2 = new ProfileAccount
		{
			name = "Einha Alliah Muday",
			username = "einhaalliahgmuday",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			bio = "Live well.",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna"
		};
		
		ProfileAccount profile3 = new ProfileAccount
		{
			name = "Danica Malana",
			username = "BSIT2-1_DanicaMalana",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			bio = "227",
			courYrSec = "BSIT 2-1",
			location = "Cabuyao City, Laguna"
		};
		
		ProfileAccount profile4 = new ProfileAccount
		{
			name = "Sarah Michelle Orejo",
			username = "BSIT2-1_SarahMichelleOrejo",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			bio = "Sarah",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna"
		};
		
		ProfileAccount profile5 = new ProfileAccount
		{
			name = "Andrea Balaba",
			username = "BSIT2-1_AndreaBalaba",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			bio = "cute",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna"
		};
		
		ProfileAccount profile6 = new ProfileAccount
		{
			name = "Razell Mae Quitalig",
			username = "_RazellMaeQuitalig",
			genderPronouns = "she/her",
			rating = "5.0 *****",
			bio = "rzllq",
			courYrSec = "BSIT 2-1",
			location = "Binan City, Laguna"
		};
		
		profileAccounts.Add(user);
		profileAccounts.Add(profile2);
		profileAccounts.Add(profile3);
		profileAccounts.Add(profile4);
		profileAccounts.Add(profile5);
		profileAccounts.Add(profile6);
		
		user.followers.Add(profile2);
		user.followers.Add(profile3);
		user.followers.Add(profile4);
		user.followers.Add(profile5);
		user.followers.Add(profile6);
		
		user.following.Add(profile2);
		user.following.Add(profile4);
		user.following.Add(profile5);
		user.following.Add(profile6);
	}
}
