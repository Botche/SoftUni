using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P07_PrintMinionsNames
{
    class StartUp
    {
        private static string connectionString =
               @"Server=.\SQLEXPRESS;" +
               "Database=MinionsDB;" +
               "Integrated Security=true;";

        static void Main(string[] args)
        {
            List<string> minionsName = new List<string>();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                try
                {
                    string queryTextForMinions = @"SELECT * FROM Minions";

                    SqlCommand minionsNamesCmd = new SqlCommand(queryTextForMinions, connection);

                    using (minionsNamesCmd)
                    {
                        SqlDataReader reader = minionsNamesCmd.ExecuteReader();
                        using (reader)
                        {
                            while (reader.Read())
                            {
                                minionsName.Add((string)reader["Name"]);
                            }
                        }

                        int counter = 0;
                        for (int i = 0; i < minionsName.Count; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.WriteLine(minionsName[counter]);
                            }
                            else
                            {
                                Console.WriteLine(minionsName[minionsName.Count - counter - 1]);
                                counter++;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Select failed");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}