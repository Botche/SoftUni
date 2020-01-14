using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var word in words)
            {
                string lowerWord = word.ToLower();
                if (counts.ContainsKey(lowerWord))
                    counts[lowerWord]++;
                else
                    counts.Add(lowerWord, 1);
            }
            foreach (var count in counts)
            {
                if (count.Value % 2 == 1)
                    Console.Write(count.Key + " ");
            }
        }
    }
}
