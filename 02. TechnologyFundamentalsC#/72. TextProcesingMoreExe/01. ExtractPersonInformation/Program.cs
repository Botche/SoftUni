using System;
using System.Text.RegularExpressions;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Regex patternName = new Regex(@"\@(?<name>([A-z]*?))\|");
            Regex patternAge = new Regex(@"\#(?<age>\d*?)\*");
            for (int i = 0; i < length; i++)
            {
                string str = Console.ReadLine();
                Match matchName = patternName.Match(str);
                Match matchAge = patternAge.Match(str);
                if (patternAge.IsMatch(str) && patternName.IsMatch(str))
                {
                    string name = matchName.Groups["name"].Value.ToString();
                    int age = int.Parse(matchAge.Groups["age"].Value.ToString());

                    Console.WriteLine($"{matchName.Groups["name"].Value.ToString()} is {matchAge.Groups["age"].Value.ToString()} years old.");
                }
            }
        }
    }
}
