using System;
using System.Linq;

namespace _07._PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfValidName = int.Parse(Console.ReadLine());
            string[] validNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(n=>n.Length<=lengthOfValidName)
                .ToArray();

            foreach (var name in validNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
