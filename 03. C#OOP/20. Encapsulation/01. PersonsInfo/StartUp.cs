using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();

                    var firstName = cmdArgs[0];
                    var secondName = cmdArgs[1];
                    var age = int.Parse(cmdArgs[2]);
                    var salary = decimal.Parse(cmdArgs[3]);

                    var person = new Person(firstName, secondName, age, salary);

                    people.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var team = new Team("SoftUni");

            foreach (var player in people)
            {
                team.AddPlayer(player);
            }

            Console.WriteLine(team);
        }
    }
}
