using System;
using System.Text.RegularExpressions;

namespace MatchNumberPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            string phones = Console.ReadLine();
            Regex regex = new Regex(@"([+][3][5][9])([ -])2\2\d{3}\2\d{4}\b");

            MatchCollection matches = regex.Matches(phones);

            Console.WriteLine(string.Join(", ",matches));
        }
    }
}
