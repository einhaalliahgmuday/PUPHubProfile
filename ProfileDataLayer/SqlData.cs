using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProfileDataModels;

namespace ProfileDataLayer;

public class SqlData
{
	static string connectionString;
        //= "Data Source =localhost; Initial Catalog = PUPHubPosts; Integrated Security = True;";
        //= "Server=tcp://,1433;Database=PUPPoints;User Id=sa;Password=indaleenq727!;";
        
	static SqlConnection sqlConnection;

    public SqlData()
    {
        sqlConnection = new SqlConnection(connectionString);
    }
	
	public List<RegisteredAccount> GetRegisteredAccounts
	{
		var selectStatement = "SELECT StudentNo, Username FROM RegisteredAccounts";
		SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
		sqlConnection.Open();
		SqlDataReader reader = selectCommand.ExecuteReader();
		
		var registeredAccounts = new List<RegisteredAccount>();
		
		while (reader.Read())
		{
			registeredAccounts.Add(new RegisteredAccount
			{
				studentNo = reader["StudentNo"].ToString(),
				username = reader["Username"].ToString()
			});
		}
		
		sqlConnection.Close();
		
		return registeredAccounts;
	}
	
	public void RegisterAccount(RegisteredAccount registeredAccount)	//int
    {
		//	int success;
		
        var insertStatement = "INSERT INTO RegisteredAccounts VALUES (@StudentNo, @Username)";
        SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
		insertCommand.Parameters.AddWithValue("@StudentNo", registeredAccount.studentNo);
		insertCommand.Parameters.AddWithValue("@Username", registeredAccount.username);
           
		sqlConnection.Open();

		success = insertCommand.ExecuteNonQuery();

		sqlConnection.Close();

		//	return success;
	}
	
	public List<ProfileAccount> GetProfileAccounts
	{
		var selectStatement = "SELECT Username, GenderPronouns, Rating, DateJoined, Bio FROM ProfileAccounts";	//include AccountPrivacy?
		SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
		sqlConnection.Open();
		SqlDataReader reader = selectCommand.ExecuteReader();
		
		var profileAccounts = new List<ProfileAccount>();
		
		while (reader.Read())
		{
			profileAccounts.Add(new ProfileAccount
			{
				username = reader["Username"].ToString(),
				genderPronouns = reader["GenderPronouns"].ToString(),
				rating = Convert.ToInt16(reader["Rating"].ToString(),
				dateJoined = DateTime.Now,
				bio = reader["Bio"].ToString()
			});
		}
		
		sqlConnection.Close();
		
		return profileAccounts;
	}

		
	public void CreateProfileAccount(ProfileAccount profileAccount)	//int
	{
		//	int success;
			
		var insertStatement = "INSERT INTO ProfileAccounts VALUES (@Username, @GenderPronouns, @Rating, @DateJoined, @Bio)";

		SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

		insertCommand.Parameters.AddWithValue("@Username", registeredAccount.username);
		insertCommand.Parameters.AddWithValue("@GenderPronouns", registeredAccount.genderPronouns);
		insertCommand.Parameters.AddWithValue("@Rating", registeredAccount.rating);
		insertCommand.Parameters.AddWithValue("@DateJoined", registeredAccount.dateJoined);
		insertCommand.Parameters.AddWithValue("@Bio", registeredAccount.bio);
           
		sqlConnection.Open();
		insertCommand.ExecuteNonQuery();	//success =

		sqlConnection.Close();

		//	return success;
	}
		
	public void UpdateProfileAccount(string informationToUpdate, ProfileAccount profileAccount)
	{
		SqlCommand updateCommand;
			
		if (informationToUpdate == "genderPronouns")
		{
			var updateStatement = "UPDATE ProfileAccounts SET GenderPronouns = @GenderPronouns WHERE Username = @Username";
			updateCommand = new SqlCommand(updateStatement, sqlConnection);
				
			updateCommand.Parameters.AddWithValue("@GenderPronouns", profileAccount.genderPronouns);
			updateCommand.Parameters.AddWithValue("@Username", profileAccount.username);
		}
		else if (informationToUpdate == "rating")
		{
			var updateStatement = "UPDATE ProfileAccounts SET Rating = @Rating WHERE Username = @Username";
			updateCommand = new SqlCommand(updateStatement, sqlConnection);
			
			updateCommand.Parameters.AddWithValue("@GenderPronouns", profileAccount.genderPronouns);
			updateCommand.Parameters.AddWithValue("@Username", profileAccount.username);
		}
		else if (informationToUpdate == "bio")
		{
			var updateStatement = "UPDATE ProfileAccounts SET Bio = @Bio WHERE Username = @Username";
			updateCommand = new SqlCommand(updateStatement, sqlConnection);
			
			updateCommand.Parameters.AddWithValue("@GenderPronouns", profileAccount.genderPronouns);
			updateCommand.Parameters.AddWithValue("@Username", profileAccount.username);
		}
			
		sqlConnection.Open();

		updateCommand.ExecuteNonQuery();

		sqlConnection.Close();
	}
}
