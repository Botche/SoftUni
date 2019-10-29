using System;
using System.Data;
using System.Data.SqlClient;

namespace P09_IncreaseAgeStoredProcedure
{
    class StartUp
    {
        private static string connectionString =
               @"Server=.\SQLEXPRESS;" +
               "Database=MinionsDB;" +
               "Integrated Security=true;";

        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                try
                {
                    string queryTextStoredProcedure = @"usp_GetOlder";

                    SqlCommand storedProcedureCmd = new SqlCommand(queryTextStoredProcedure, connection);

                    using (storedProcedureCmd)
                    {
                        storedProcedureCmd.CommandType = CommandType.StoredProcedure;

                        storedProcedureCmd.Parameters.Add("@id", SqlDbType.Int, 0, "id");

                        storedProcedureCmd.Parameters[0].Value = minionId;

                        storedProcedureCmd.ExecuteNonQuery();
                    }

                    string queryTextForSelect = @"SELECT Name, Age FROM Minions WHERE Id = {0}";

                    SqlCommand selectCmd = new SqlCommand(string.Format(queryTextForSelect, minionId), connection);

                    using (selectCmd)
                    {
                        SqlDataReader reader = selectCmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} - {reader["Age"]}");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured!");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
