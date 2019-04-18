using System;
using System.Text.RegularExpressions;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            double sum = 0;
            Regex pattern = new Regex(@"\b(?<firstLetter>[A-z])(?<number>\d+)(?<secondLetter>[A-z])\b");

            MatchCollection matches = pattern.Matches(str);
            foreach (Match match in matches)
            {
                char firstCh = char.Parse(match.Groups["firstLetter"].Value);
                char secondCh = char.Parse(match.Groups["secondLetter"].Value);
                double number = double.Parse(match.Groups["number"].Value);

                if (firstCh < 96)
                {
                    number /= firstCh - 64;
                }
                else
                {
                    number *= firstCh - 96;
                }
                if (secondCh < 96)
                {
                    number -= secondCh - 64;
                }
                else
                {
                    number += secondCh - 96;
                }
                sum += number;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
