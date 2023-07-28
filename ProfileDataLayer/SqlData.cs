using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProfileDataModels;

namespace ProfileDataLayer;

public class SqlData
{
	static string connectionString = "Server=localhost;Database=PUPHubProfile;Trusted_Connection=True;";
        
	static SqlConnection sqlConnection;

    public SqlData()
    {
        sqlConnection = new SqlConnection(connectionString);
    }
	
	public List<RegisteredAccount> GetRegisteredAccounts()
	{
		string selectStatement = "SELECT StudentNo, Username FROM RegisteredAccounts";
		SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
		sqlConnection.Open();
		SqlDataReader reader = selectCommand.ExecuteReader();
		
		List<RegisteredAccount> registeredAccounts = new List<RegisteredAccount>();
		
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
	
	public void RegisterAccount(RegisteredAccount registeredAccount)
    {	
        var insertStatement = "INSERT INTO RegisteredAccounts VALUES (@StudentNo, @Username)";
        SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
		insertCommand.Parameters.AddWithValue("@StudentNo", registeredAccount.studentNo);
		insertCommand.Parameters.AddWithValue("@Username", registeredAccount.username);
           
		sqlConnection.Open();

		insertCommand.ExecuteNonQuery();

		sqlConnection.Close();
	}
	
	public void DeleteRegisteredAccount(RegisteredAccount registeredAccount) 
	{
		var deleteStatement = "DELETE FROM RegisteredAccounts WHERE Username = @Username";
		SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
		sqlConnection.Open();
		
		deleteCommand.Parameters.AddWithValue("@Username", registeredAccount.username);
		
		deleteCommand.ExecuteNonQuery();
		
		sqlConnection.Close();
	}	
	
	public List<ProfileAccount> GetProfileAccounts()
	{
		var selectStatement = "SELECT Username, GenderPronouns, Rating, DateJoined, Bio FROM ProfileAccounts";
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
				rating = reader["Rating"].ToString(),
				dateJoined = DateTime.Now,
				bio = reader["Bio"].ToString()
			});
		}
		
		sqlConnection.Close();
		
		return profileAccounts;
	}

		
	public void CreateProfileAccount(ProfileAccount profileAccount)
	{
		var insertStatement = "INSERT INTO ProfileAccounts VALUES (@Username, @GenderPronouns, @Rating, @DateJoined, @Bio)";

		SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

		insertCommand.Parameters.AddWithValue("@Username", profileAccount.username);
		insertCommand.Parameters.AddWithValue("@GenderPronouns", profileAccount.genderPronouns);
		insertCommand.Parameters.AddWithValue("@Rating", profileAccount.rating);
		insertCommand.Parameters.AddWithValue("@DateJoined", profileAccount.dateJoined);
		insertCommand.Parameters.AddWithValue("@Bio", profileAccount.bio);
           
		sqlConnection.Open();
		insertCommand.ExecuteNonQuery();

		sqlConnection.Close();
	}
		
	public void UpdateProfileAccount(ProfileAccount profileAccount, string informationToUpdate, string updatedInformation)
	{
		sqlConnection.Open();
		
		SqlCommand updateCommand;
			
		if (informationToUpdate == "Gender Pronouns")
		{
			var updateStatement = "UPDATE ProfileAccounts SET GenderPronouns = @GenderPronouns WHERE Username = @Username";
			updateCommand = new SqlCommand(updateStatement, sqlConnection);
				
			updateCommand.Parameters.AddWithValue("@GenderPronouns", updatedInformation);
			updateCommand.Parameters.AddWithValue("@Username", profileAccount.username);
			
			updateCommand.ExecuteNonQuery();
		}
		else if (informationToUpdate == "Rating")
		{
			var updateStatement = "UPDATE ProfileAccounts SET Rating = @Rating WHERE Username = @Username";
			updateCommand = new SqlCommand(updateStatement, sqlConnection);
			
			updateCommand.Parameters.AddWithValue("@Rating", updatedInformation);
			updateCommand.Parameters.AddWithValue("@Username", profileAccount.username);
			
			updateCommand.ExecuteNonQuery();
		}
		else if (informationToUpdate == "Bio")
		{
			var updateStatement = "UPDATE ProfileAccounts SET Bio = @Bio WHERE Username = @Username";
			updateCommand = new SqlCommand(updateStatement, sqlConnection);
			
			updateCommand.Parameters.AddWithValue("@Bio", updatedInformation);
			updateCommand.Parameters.AddWithValue("@Username", profileAccount.username);
			
			updateCommand.ExecuteNonQuery();
		}

		sqlConnection.Close();
	}
	
	public void DeleteProfileAccount(ProfileAccount profileAccount) 
	{
		var deleteStatement = "DELETE FROM ProfileAccounts WHERE Username = @Username";
		SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
		sqlConnection.Open();
		
		deleteCommand.Parameters.AddWithValue("@Username", profileAccount.username);
		
		deleteCommand.ExecuteNonQuery();
		
		sqlConnection.Close();
	}
}
