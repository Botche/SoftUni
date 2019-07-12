using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _03._WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("words.txt"))
            {
                string[] words = reader.ReadLine()
                    .Split();
                Dictionary<string, int> counterWords = new Dictionary<string, int>();
                for (int i = 0; i < words.Length; i++)
                {
                    if (!counterWords.ContainsKey(words[i]))
                    {
                        counterWords.Add(words[i], 0);
                    }
                }
                using (var readerOfText=new StreamReader("text.txt"))
                {
                    string line = readerOfText.ReadLine();

                    while (line!=null)
                    {
                        char[] splitters = new char[] {'.',' ','?',',','-','!'};
                        string[] wordsFromLine = line.ToLower()
                            .Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in wordsFromLine)
                        {
                            if (counterWords.ContainsKey(word))
                            {
                                counterWords[word]++;
                            }
                        }
                        line = readerOfText.ReadLine();
                    }

                    using (var writer=new StreamWriter("Output.txt"))
                    {
                        var sortedCounter = counterWords.OrderByDescending(x=>x.Value);
                        foreach (var (word,counter) in sortedCounter)
                        {
                            writer.WriteLine($"{word} - {counter}");
                        }
                    }
                }
            }
        }
    }
}
