using System;

namespace sumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int br = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < br; i++)
            {
                char ch = char.Parse(Console.ReadLine());
                sum += ch;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
