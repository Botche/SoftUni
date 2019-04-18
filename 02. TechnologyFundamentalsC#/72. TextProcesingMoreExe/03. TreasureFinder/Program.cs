using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string input = Console.ReadLine();
            Regex typePattern = new Regex(@"(?<=\&)([A-z]*?)(?=\&)");
            Regex coordinatesPattern = new Regex(@"(?<=\<)(\w*?)(?=\>)");
            string newStr = "";
            while (input != "find")
            {
                int j = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    newStr += (char)(input[i] - numbers[j]);
                    j++;
                    if (j == numbers.Length)
                        j = 0;
                }
                if (typePattern.IsMatch(newStr) && coordinatesPattern.IsMatch(newStr))
                {
                    Match matchType = typePattern.Match(newStr);
                    Match matchCoordinates = coordinatesPattern.Match(newStr);

                    Console.WriteLine($"Found {matchType} at {matchCoordinates}");
                }
                newStr = "";
                input = Console.ReadLine();
            }
        }
    }
}
