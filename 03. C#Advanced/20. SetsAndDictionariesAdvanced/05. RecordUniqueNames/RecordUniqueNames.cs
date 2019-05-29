using System;
using System.Collections.Generic;

namespace _05._RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();

                uniqueNames.Add(input);
            }

            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
