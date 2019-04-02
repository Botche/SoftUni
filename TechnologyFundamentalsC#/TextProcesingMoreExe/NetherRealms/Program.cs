using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input
            string[] input = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            SortedDictionary<string, Dictionary<int, decimal>> demons = new SortedDictionary<string, Dictionary<int, decimal>>();

            Regex patternForHp = new Regex(@"[^\d+\-*\/.]");
            Regex patternForMinus = new Regex(@"(?<=[-])(\d+(\.\d+)?)");
            Regex patternForPlus = new Regex(@"(?<=[^\d+\-*\/.])(\d+(\.\d+)?)");
            Regex patternForMultiOrDivide = new Regex(@"[*]|[\/]");

            foreach (var demon in input)
            {
                int hp = 0;
                MatchCollection matchesForHp = patternForHp.Matches(demon);
                foreach (Match match in matchesForHp)
                {
                    char ch = char.Parse(match.ToString());
                    hp += ch;
                }

                decimal dmg = 0;
                MatchCollection matchesForPlus = patternForPlus.Matches(demon);
                foreach (Match num in matchesForPlus)
                {
                    decimal numb = decimal.Parse(num.ToString());
                    dmg += numb;
                }
                MatchCollection matchesForMinus = patternForMinus.Matches(demon);
                foreach (Match num in matchesForMinus)
                {
                    decimal numb = decimal.Parse(num.ToString());
                    dmg -= numb;
                }
                MatchCollection matchesForMulti = patternForMultiOrDivide.Matches(demon);
                foreach (Match sign in matchesForMulti)
                {
                    if (sign.ToString() == "*")
                        dmg *= 2;
                    else if (sign.ToString() == "/")
                        dmg /= 2;
                }

                demons.Add(demon, new Dictionary<int, decimal>());
                demons[demon].Add(hp, dmg);

            }
            foreach (var demon in demons)
            {
                foreach (var stat in demon.Value)
                {
                    if (stat.Key != 0)
                        Console.WriteLine($"{demon.Key} - {stat.Key} health, {stat.Value:f2} damage");
                }
            }
        }
    }
}

