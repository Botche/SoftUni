using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.Models;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command=Console.ReadLine())!="End")
            {
                string[] tokens = command.Split();

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson citizen = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(resident.GetName());
                Console.WriteLine(citizen.GetName());
            }
        }
    }
}
