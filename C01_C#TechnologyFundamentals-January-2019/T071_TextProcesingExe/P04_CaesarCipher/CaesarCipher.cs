using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string newStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                newStr += (char)(str[i] + 3);
            }
            Console.WriteLine(newStr);
        }
    }
}
