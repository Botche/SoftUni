using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = null;

            while ((command = Console.ReadLine()) != "Output")
            {
                string[] tokens = command
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                var departament = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + secondName;

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int room = 0; room < 20; room++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool isFree = departments[departament]
                    .SelectMany(x => x)
                    .Count() < 60;
                if (isFree)
                {
                    int currentRoom = 0;
                    doctors[fullName].Add(patient);
                    for (int room = 0; room < departments[departament].Count; room++)
                    {
                        if (departments[departament][room].Count < 3)
                        {
                            currentRoom = room;
                            break;
                        }
                    }
                    departments[departament][currentRoom].Add(patient);
                }
            }

            while ((command=Console.ReadLine()) != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]]
                        .Where(x => x.Count > 0)
                        .SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1]
                        .OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]]
                        .OrderBy(x => x)));
                }
            }
        }
    }
}
