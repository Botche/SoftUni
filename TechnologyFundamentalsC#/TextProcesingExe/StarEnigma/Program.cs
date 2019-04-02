using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int count = 0;
            string newStr = "";
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();
                newStr = "";
                count = 0;
                //count decrypt Key
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 's' ||
                        input[j] == 't' ||
                        input[j] == 'a' ||
                        input[j] == 'r' ||
                        input[j] == 'S' ||
                        input[j] == 'T' ||
                        input[j] == 'A' ||
                        input[j] == 'R')
                    {
                        count++;
                    }
                }
                //Decrypt
                for (int j = 0; j < input.Length; j++)
                {
                    newStr += (char)(input[j] - count);
                }
                //Takes Info
                Regex pattern = new Regex(@"(?<planetName>(?<=@)[A-Z][a-z]+)(?:[^@:!\->]*):(?<population>\d+)([!])(?<position>[AD])!(?:[^@:!\->]*)->(?<soljerCout>\d+)");
                MatchCollection matches = pattern.Matches(newStr);
                //Check for property info
                foreach (Match kvp in matches)
                {
                    string atackedOrDestroy = kvp.Groups["position"].Value;
                    string planetName = kvp.Groups["planetName"].Value;
                    if (atackedOrDestroy == "A" )
                    {
                        attacked.Add(planetName);
                    }
                    else if (atackedOrDestroy == "D" )
                    {
                        destroyed.Add(planetName);
                    }
                }
            }
            //Output
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var planet in attacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var planet in destroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
