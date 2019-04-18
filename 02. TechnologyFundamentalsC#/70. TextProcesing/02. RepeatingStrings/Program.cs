using System;
using System.Text;

namespace RepeatingStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                string wordToRepeat = input[i];
                for (int j = 0; j < wordToRepeat.Length; j++)
                {
                    result.Append(wordToRepeat);
                }
            }
            Console.WriteLine(result);
        }
    }
}
