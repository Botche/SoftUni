using System;
using System.Data.SqlClient;

namespace P06_DeleteVillian
{
    class StartUp
    {
        private static string connectionString =
               @"Server=.\SQLEXPRESS;" +
               "Database=MinionsDB;" +
               "Integrated Security=true;";

        static void Main(string[] args)
        {
            int villianId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    string villianName = string.Empty;
                    int minionsReleased = -1;

                    string queryTextForVillianName = @"SELECT Name FROM Villains WHERE Id = {0}";
                    SqlCommand villianCmd = new SqlCommand(string.Format(queryTextForVillianName, villianId), connection, transaction);

                    using (villianCmd)
                    {
                        villianName = (string)villianCmd.ExecuteScalar();

                        if (villianName == null)
                        {
                            Console.WriteLine("No such villain was found.");
                            return;
                        }
                    }

                    string queryTextForMinionsReleased = @"DELETE FROM MinionsVillains 
                                                           WHERE VillainId = {0}";

                    SqlCommand releasedMinionsCmd = new SqlCommand(string.Format(queryTextForMinionsReleased, villianId), connection, transaction);

                    using (releasedMinionsCmd)
                    {
                        minionsReleased = releasedMinionsCmd.ExecuteNonQuery();
                    }

                    string queryTextForVillianDelete = @"DELETE FROM Villains 
                                                           WHERE Id = {0}";

                    SqlCommand deleteVillianCmd = new SqlCommand(string.Format(queryTextForVillianDelete, villianId), connection, transaction);

                    using (deleteVillianCmd)
                    {
                        deleteVillianCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    Console.WriteLine($"{villianName} was deleted.");
                    Console.WriteLine($"{minionsReleased} minions were released.");
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Deleting failed!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
