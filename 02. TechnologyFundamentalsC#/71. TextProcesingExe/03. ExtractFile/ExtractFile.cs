using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileToExtract = Console.ReadLine();
            int startIndex = fileToExtract.LastIndexOf('\\') + 1;
            string[] file = fileToExtract.Substring(startIndex).Split(".");

            Console.WriteLine($"File name: {file[0]}");
            Console.WriteLine($"File extension: {file[1]}");
        }
    }
}
