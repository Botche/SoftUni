using System;
using System.Text.RegularExpressions;

namespace MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string nums = Console.ReadLine();
            Regex pattern = new Regex(@"(^|(?<=\s))-?\d+?(\.\d+)?($|(?=\s))");

            MatchCollection matches = pattern.Matches(nums);
            Console.WriteLine(string.Join(" ",matches));
        }
    }
}
