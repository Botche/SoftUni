using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Dictionary<char, int> counterOfChars = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (!counterOfChars.ContainsKey(ch))
                {
                    counterOfChars.Add(ch, 0);
                }
                counterOfChars[ch]++;
            }

            var sortedDict = counterOfChars
                .OrderBy(x => x.Key)
                .ToDictionary(x=>x.Key,y=>y.Value);
            foreach (var ch in sortedDict)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
