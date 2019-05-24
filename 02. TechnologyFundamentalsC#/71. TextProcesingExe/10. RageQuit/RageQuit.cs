using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Regex pattern = new Regex(@"(?<stringToRepeat>(?<strings>\D+)(?<numbers>\d+))");
            StringBuilder sb = new StringBuilder();
            List<char> chars = new List<char>();

            MatchCollection matches = pattern.Matches(str);
            foreach (Match match in matches)
            {
                string strToRepeat = match.Groups["strings"].Value;
                int timesToRepeat = int.Parse(match.Groups["numbers"].Value);
                strToRepeat = strToRepeat.ToUpper();
                //count unique symbols
                for (int i = 0; i < strToRepeat.Length; i++)
                {
                    if (!chars.Contains(strToRepeat[i]) && timesToRepeat != 0)
                        chars.Add(strToRepeat[i]);
                }
                //makes new string (repeated)
                for (int i = 1; i <= timesToRepeat; i++)
                {
                    sb.Append(strToRepeat);
                }
            }
            //Output
            Console.WriteLine($"Unique symbols used: {chars.Count}");
            Console.WriteLine(sb);
        }
    }
}
