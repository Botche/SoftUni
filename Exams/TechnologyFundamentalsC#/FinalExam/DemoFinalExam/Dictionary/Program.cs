using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" | ");
            SortedDictionary<string, List<string>> wordsWithDescriptions = new SortedDictionary<string, List<string>>();

            string[] words = Console.ReadLine().Split(" | ");

            string command = Console.ReadLine();

            foreach (var element in input)
            {
                string[] elements = element.Split(": ");
                string word = elements[0];

                if (!wordsWithDescriptions.ContainsKey(word))
                {
                    wordsWithDescriptions.Add(word, new List<string>());
                }

                string description = elements[1];
                wordsWithDescriptions[word].Add(description);
            }
            if (command == "End")
            {
                foreach (var word in words)
                {
                    if (wordsWithDescriptions.ContainsKey(word))
                    {
                        Console.WriteLine(word);
                        foreach (var description in wordsWithDescriptions[word].OrderByDescending(x => x.Length))
                        {
                            Console.WriteLine($" -{description}");
                        }
                    }
                }
            }
            else if (command == "List")
            {
                Console.WriteLine(string.Join(" ", wordsWithDescriptions.Keys));
            }

        }
    }
}
