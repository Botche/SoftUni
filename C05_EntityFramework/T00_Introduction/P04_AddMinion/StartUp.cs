using System;
using System.Data.SqlClient;

namespace P04_AddMinion
{
    class StartUp
    {
        private const string connectionString =
            @"Server=.\SQLEXPRESS;" +
            "Database=MinionsDB;" +
            "Integrated Security=true;";

        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];

            string[] villianInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string villianName = villianInfo[1];

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlTransaction transaction = null;
            using (connection)
            {
                transaction = connection.BeginTransaction();
                try
                {
                    string queryTextForVillian = @"SELECT Id FROM Villains WHERE Name = '{0}'";

                    SqlCommand villiandCmd = new SqlCommand(string.Format(queryTextForVillian, villianName), connection, transaction);

                    using (villiandCmd)
                    {
                        var villian = villiandCmd.ExecuteScalar();

                        if (villian == null)
                        {
                            string queryTextForAddingVillian = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES ('{0}', 4)";

                            SqlCommand addVillian = new SqlCommand(string.Format(queryTextForAddingVillian, villianName), connection, transaction);

                            using (addVillian)
                            {
                                addVillian.ExecuteNonQuery();

                                Console.WriteLine($"Villain {villianName} was added to the database.");
                            }
                        }
                    }

                    string queryTextForTown = @"SELECT Id FROM Towns WHERE Name = '{0}'";

                    SqlCommand townCmd = new SqlCommand(string.Format(queryTextForTown, minionTown), connection, transaction);
                    using (townCmd)
                    {
                        var town = townCmd.ExecuteScalar();

                        if (town == null)
                        {
                            string queryTextForAddingTown = @"INSERT INTO Towns (Name) VALUES ('{0}')";

                            SqlCommand addTown = new SqlCommand(string.Format(queryTextForAddingTown, minionTown), connection, transaction);
                            using (addTown)
                            {
                                addTown.ExecuteNonQuery();

                                Console.WriteLine($"Town {minionTown} was added to the database.");
                            }
                        }

                    }
                    string queryTextForMinion = @"SELECT Id FROM Minions WHERE Name = '{0}'";

                    SqlCommand minionCmd = new SqlCommand(string.Format(queryTextForMinion, minionName), connection, transaction);
                    using (minionCmd)
                    {
                        var minion = minionCmd.ExecuteScalar();

                        if (minion == null)
                        {
                            string queryTextForAddingMinion = @"INSERT INTO Minions (Name, Age, TownId) VALUES ('{0}', {1}, {2})";

                            int townId = (int)townCmd.ExecuteScalar();

                            SqlCommand addMinion = new SqlCommand(string.Format(queryTextForAddingMinion, minionName, minionAge, townId), connection, transaction);

                            using (addMinion)
                            {
                                addMinion.ExecuteNonQuery();
                            }
                        }

                        string queryTextForFetchMinionToVillian = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES ({0}, {1})";

                        minion = minionCmd.ExecuteScalar();
                        var villian = villiandCmd.ExecuteScalar();

                        SqlCommand fetchMinionToVillian = new SqlCommand(string.Format(queryTextForFetchMinionToVillian, (int)minion, (int)villian), connection, transaction);

                        using (fetchMinionToVillian)
                        {
                            fetchMinionToVillian.ExecuteNonQuery();

                            Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}.");
                        }
                    }

                    transaction.Commit();   
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction failed");
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
