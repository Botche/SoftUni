using System;

namespace AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCh = char.Parse(Console.ReadLine());
            char secondCh = char.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (ch > firstCh && ch < secondCh)
                    sum += ch;
            }

            Console.WriteLine(sum);
        }
    }
}
