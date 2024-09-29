using System;
using System.Data.SqlClient;

namespace MyDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using Windows Authentication to access DB
            string connectionString = "data source=BettPC\\SQLEXPRESS;initial catalog=MyDb;trusted_connection=true";

            // Create a SQL connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();
                    Console.WriteLine("Connection successful!");

                    // Execute a simple query
                    string query = "SELECT TOP 1 * FROM Courses";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        // Read and display the result
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
