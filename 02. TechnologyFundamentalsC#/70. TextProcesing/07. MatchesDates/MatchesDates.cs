using System;
using System.Text.RegularExpressions;

namespace MatchesDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();
            Regex pattern = new Regex(@"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");

            MatchCollection matches = pattern.Matches(dates);

            foreach (Match match in matches)
            {
                var day = match.Groups["day"].Value;
                var month = match.Groups["month"].Value;
                var year = match.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
