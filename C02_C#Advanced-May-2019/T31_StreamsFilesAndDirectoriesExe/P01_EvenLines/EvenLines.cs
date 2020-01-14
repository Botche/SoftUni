using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01._EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> oddLines = new List<string>();
            using (var reader = File.OpenText("text.txt"))
            {
                string line = reader.ReadLine();
                int counter = 0;
                char[] splitters = new char[] { '-', ',', '.', '!', '?' };
                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (splitters.Contains(line[i]))
                            {
                                line=line.Replace(line[i], '@');
                            }
                        }
                        oddLines.Add(line);
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }

            using (var writter = File.CreateText("Output.txt"))
            {
                foreach (var line in oddLines)
                {
                    string newLine = String.Join(" ", line.Split(' ').Reverse());
                    writter.WriteLine(newLine);
                }
            }
        }
    }
}
