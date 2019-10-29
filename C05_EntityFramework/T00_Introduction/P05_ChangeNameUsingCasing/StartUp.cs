using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P05_ChangeNameUsingCasing
{
    class StartUp
    {
        private static string connectionString =
            @"Server=.\SQLEXPRESS;" +
            "Database=MinionsDB;" +
            "Integrated Security=true;";

        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                int rowsEffected = -1;

                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();
                    string queryUpdateText = @"UPDATE Towns
                                         SET Name = UPPER(Name)
                                         WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = '{0}')";

                    SqlCommand updateCmd = new SqlCommand(string.Format(queryUpdateText, country), connection, transaction);

                    using (updateCmd)
                    {
                        rowsEffected = updateCmd.ExecuteNonQuery();
                    }

                    string queryTextForSelect = @"SELECT t.Name 
                                            FROM Towns as t
                                            JOIN Countries AS c ON c.Id = t.CountryCode
                                            WHERE c.Name = '{0}'";

                    SqlCommand selectCmd = new SqlCommand(string.Format(queryTextForSelect, country), connection, transaction);

                    using (selectCmd)
                    {
                        List<string> cities = new List<string>();

                        SqlDataReader reader = selectCmd.ExecuteReader();

                        using (reader)
                        {
                            while (reader.Read())
                            {
                                cities.Add((string)reader[0]);
                            }
                        }

                        if (cities.Count == 0)
                        {
                            Console.WriteLine("No town names were affected.");
                        }
                        else
                        {
                            Console.WriteLine($"{rowsEffected} town names were affected.");
                            Console.WriteLine($"[{string.Join(", ", cities)}]");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction failed");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
