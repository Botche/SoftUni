using System;
using System.Data.SqlClient;

namespace P02_VilliansNames
{
    class StartUp
    {
        private const string connectionString =
            @"Server=.\SQLEXPRESS;" +
            "Database=MinionsDB;" +
            "Integrated Security=true;";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                string queryText = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                    FROM Villains AS v
                                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                    GROUP BY v.Id, v.Name
                                    HAVING COUNT(mv.VillainId) > 3
                                    ORDER BY COUNT(mv.VillainId)";
                SqlCommand command = new SqlCommand(queryText, connection);

                using (command)
                {
                    try
                    {
                        var reader = command.ExecuteReader();

                        using (reader)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["Name"] + " - " + reader["MinionsCount"]);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Än errors occured!");
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
            }
        }
    }
}
