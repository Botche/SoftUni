using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = "text.txt";
            string wordsPath = "words.txt";

            string[] allLines = File.ReadAllLines(textPath);
            string[] allWords = File.ReadAllLines(wordsPath);

            char[] splitters = new char[] { '.', ' ', '?', ',', '-', '!' };

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (var word in allWords)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }
            }
            foreach (var line in allLines)
            {
                string[] words = line.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    var lowerWord = word.ToLower();
                    if (allWords.Contains(lowerWord))
                    {
                        wordsCount[lowerWord]++;
                    }
                }
            }
            // Actual result
            string actualResultPath = "actualResults.txt";
            using (var writer = File.CreateText(actualResultPath))
            {
                foreach (var (word, counter) in wordsCount)
                {
                    writer.WriteLine($"{word} - {counter}");
                }
            }
            // Expected Result
            var sortedDict = wordsCount.OrderByDescending(x => x.Value)
                .ToDictionary(x=>x.Key,y=>y.Value);
            string expectedResultPath = "expectedResult.txt";
            using (var writer = File.CreateText(expectedResultPath))
            {
                foreach (var (word, counter) in sortedDict)
                {
                    writer.WriteLine($"{word} - {counter}");
                }
            }
        }
    }
}
