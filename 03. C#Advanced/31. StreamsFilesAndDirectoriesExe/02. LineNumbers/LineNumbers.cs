using System;
using System.IO;
using System.Linq;

namespace _02._LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("text.txt");

            using (var writer = File.CreateText("Output.txt"))
            {
                int counter = 1;
                foreach (var currentLine in text)
                {
                    int lettersCount = currentLine.Count(char.IsLetter);
                    int punctCount = currentLine.Count(char.IsPunctuation);

                    writer.WriteLine($"Line {counter}: {currentLine} ({lettersCount})({punctCount})");

                    counter++;
                }
            }
        }
    }
}
