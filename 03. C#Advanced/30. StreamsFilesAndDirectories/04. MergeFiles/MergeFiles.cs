using System;
using System.Collections.Generic;
using System.IO;

namespace _04._MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> mergedFiles = new List<int>();

            using (var firstReader=new StreamReader("FileOne.txt"))
            {
                string line = firstReader.ReadLine();
                while (line!=null)
                {
                    int currentNumFromFile = int.Parse(line);
                    mergedFiles.Add(currentNumFromFile);
                    line = firstReader.ReadLine();
                }
            }

            using (var secondReader = new StreamReader("FileTwo.txt"))
            {
                string line = secondReader.ReadLine();
                while (line != null)
                {
                    int currentNumFromFile = int.Parse(line);
                    mergedFiles.Add(currentNumFromFile);
                    line = secondReader.ReadLine();
                }
            }

            using (var finalWriter=new StreamWriter("Output.txt"))
            {
                mergedFiles.Sort();
                foreach (var num in mergedFiles)
                {
                    finalWriter.WriteLine(num);
                }
            }
        }
    }
}
