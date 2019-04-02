using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();
            for (int i = 0; i < length; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if(!synonyms.ContainsKey(word))
                {
                    synonyms.Add(word,new List<string>());
                }
                synonyms[word].Add(synonym);
            }
            foreach (var word in synonyms)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ",word.Value)}");
            }
        }
    }
}
