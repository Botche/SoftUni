using System;

namespace middleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            ReturnMiddleCharacters(str);
        }

        private static void ReturnMiddleCharacters(string str)
        {
            if (str.Length % 2 == 1)
                Console.WriteLine(str[str.Length / 2]);
            else
                Console.WriteLine($"{str[str.Length / 2-1]}{str[str.Length / 2]}");
        }
    }
}
