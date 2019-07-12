using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> births = new List<string>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string birthDate = string.Empty;

                if (tokens.Length == 3)
                {
                    if (tokens[2].Contains("/"))
                    {
                        birthDate = tokens[2];
                    } 
                }
                else
                {
                    birthDate = tokens[4];
                }
                births.Add(birthDate);
            }
            string birthToCompare = Console.ReadLine();

            foreach (var birth in births)
            {
                if (birth.EndsWith(birthToCompare))
                {
                    Console.WriteLine(birth);
                }
            }
        }
    }
}
