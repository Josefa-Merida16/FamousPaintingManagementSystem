using FamousPaintingManagementModels;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;


namespace FamousPaintingManagementData
{
    public class SqlDbData
    {
        string connectionString = "Data Source = LAPTOP-K066AQOL\\SQLEXPRESS ; Initial Catalog = FamousPaintingManagementSystem ; Integrated Security = True;";
        // string connection = "Server = tcp:20.198.177.117,1433;Database=FamousPaintingManagementSystem; User Id=sa; Password=Mjv_Merida0816;";
        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<FamousPainting> GetFamousPaintings()
        {
            string selectStatement = "SELECT Title, Artist, YearCreated, Status FROM Buyer";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<FamousPainting> paintings = new List<FamousPainting>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                FamousPainting painting = new FamousPainting
                {
                    Title = reader["Title"].ToString(),
                    Artist = reader["Artist"].ToString(),
                    YearCreated = Convert.ToInt32(reader["YearCreated"]),
                    Status = Convert.ToInt32(reader["Status"])
                };

                paintings.Add(painting);
            }

            sqlConnection.Close();
            return paintings;
        }

        public int AddFamousPainting(string Title, String Artist, int YearCreated, int Status)
        {
            int success;
            string insertStatement = "INSERT INTO Buyer (Title, Artist, YearCreated, Status) VALUES (@Title, @Artist, @YearCreated, @Status)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Title", Title);
            insertCommand.Parameters.AddWithValue("@Artist", Artist);
            insertCommand.Parameters.AddWithValue("@YearCreated", YearCreated);
            insertCommand.Parameters.AddWithValue("@Status", Status);

            sqlConnection.Open();
            success = insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int UpdateFamousPainting(string Title, string Artist, int YearCreated, int Status)
        {
            int success;
            string updateStatement = "UPDATE Buyer SET Artist = @Artist, YearCreated = @YearCreated, Status = @Status WHERE Title = @Title";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Title", Title);
            updateCommand.Parameters.AddWithValue("@Artist", Artist);
            updateCommand.Parameters.AddWithValue("@YearCreated", YearCreated);
            updateCommand.Parameters.AddWithValue("@Status", Status);

            sqlConnection.Open();
            success = updateCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int DeleteFamousPainting(string Title)
        {
            int success;
            string deleteStatement = "DELETE FROM Buyer WHERE Title = @Title";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);

            deleteCommand.Parameters.AddWithValue("@Title", Title);

            sqlConnection.Open();
            success = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }
    }
}