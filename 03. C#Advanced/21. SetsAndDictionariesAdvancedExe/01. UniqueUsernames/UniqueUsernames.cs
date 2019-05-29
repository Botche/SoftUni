using System;
using System.Collections.Generic;

namespace _01._UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            int length = int.Parse(Console.ReadLine());

            for (int i = 0; i < length; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
