using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            Dictionary<char, int> counts = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                char letter = words[i];
                if(letter!=' ')
                {
                    if (counts.ContainsKey(letter))
                        counts[letter]++;
                    else
                        counts.Add(letter, 1);
                }
            }

            foreach (var letter in counts)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
