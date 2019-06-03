using System;
using System.Linq;

namespace _03._CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] uppercaseWords = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToArray();

            foreach (var word in uppercaseWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
