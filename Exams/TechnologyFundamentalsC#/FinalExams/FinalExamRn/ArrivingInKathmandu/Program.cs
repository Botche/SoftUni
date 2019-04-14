using System;
using System.Text.RegularExpressions;

namespace ArrivingInKathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"^(?<peakName>[A-Za-z0-9#!?@$]+)=(?<length>\d+)<<(?<geoHashCode>\w+)$");
            
            while (input!="Last note")
            {
                bool isValidName = pattern.IsMatch(input);
                if (!isValidName)
                {
                    Console.WriteLine("Nothing found!");
                    input = Console.ReadLine();
                    continue;
                }
                Match match = pattern.Match(input);
                string cryptedName = match.Groups["peakName"].Value;
                int length = int.Parse(match.Groups["length"].Value);
                string geoHashCode = match.Groups["geoHashCode"].Value;

                string name = "";
                for (int i = 0; i < cryptedName.Length; i++)
                {
                    if (char.IsLetterOrDigit(cryptedName[i]))
                    {
                        name += cryptedName[i];
                    }
                }
                if (geoHashCode.Length==length)
                {
                    Console.WriteLine($"Coordinates found! {name} -> {geoHashCode}");
                }
                else
                    Console.WriteLine("Nothing found!");

                input = Console.ReadLine();
            }
        }
    }
}
