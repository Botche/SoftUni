using System;
using System.Data.SqlClient;

namespace P03_MinionNames
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
                string queryTextForVillian = @"SELECT Name FROM Villains WHERE Id = {0}";
                string queryTextForMinions = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                    m.Name, 
                                                    m.Age
                                                FROM MinionsVillains AS mv
                                                JOIN Minions As m ON mv.MinionId = m.Id
                                                WHERE mv.VillainId = {0}
                                                ORDER BY m.Name";

                int villiandId = int.Parse(Console.ReadLine());

                SqlCommand commandForVillian = new SqlCommand(string.Format(queryTextForVillian, villiandId), connection);
                SqlCommand commandForMinions = new SqlCommand(string.Format(queryTextForMinions, villiandId), connection);
                using (commandForVillian)
                {
                    using (commandForMinions)
                    {
                        try
                        {
                            string villianName = (string)commandForVillian.ExecuteScalar();

                            if (villianName == null)
                            {
                                Console.WriteLine($"No villain with ID {villiandId} exists in the database.");
                                return;
                            }

                            Console.WriteLine($"Villain: {villianName}");

                            SqlDataReader reader = commandForMinions.ExecuteReader();

                            using (reader)
                            {
                                if (!reader.HasRows)
                                {
                                    Console.WriteLine("(no minions)");
                                    return;
                                }
                                while (reader.Read())
                                {
                                    Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An errors occured!");
                            Console.WriteLine(e.Message);
                            return;
                        }
                    }
                }
            }
        }
    }
}
