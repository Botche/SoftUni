using System;
using System.Data.SqlClient;
using System.Linq;

namespace P08_IncreaseMinionAge
{
    class StartUp
    {
        private static string connectionString =
               @"Server=.\SQLEXPRESS;" +
               "Database=MinionsDB;" +
               "Integrated Security=true;";

        static void Main(string[] args)
        {
            int[] minionsId = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                try
                {
                    string queryTextForUpdate = @"UPDATE Minions
                                            SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                            WHERE Id = {0}";

                    foreach (var minionId in minionsId)
                    {
                        SqlCommand updateMinionCmd = new SqlCommand(string.Format(queryTextForUpdate, minionId), connection);

                        using (updateMinionCmd)
                        {
                            updateMinionCmd.ExecuteNonQuery();
                        }
                    }

                    string queryTextForSelect = @"SELECT Name, Age FROM Minions";

                    SqlCommand selectCmd = new SqlCommand(queryTextForSelect, connection);

                    using (selectCmd)
                    {
                        SqlDataReader reader = selectCmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
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
