using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfNames = Console.ReadLine();
            Regex pattern = new Regex(@"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b");
            MatchCollection matches = pattern.Matches(listOfNames);

            Console.WriteLine(string.Join(" ",matches));
        }
    }
}
