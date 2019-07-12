using System;

namespace decryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char ch = char.MaxValue;
            string str = "";
            for (int i = 0; i < n; i++)
            {
                ch = char.Parse(Console.ReadLine());
                str += (char)(ch + key);
            }
            Console.WriteLine($"{str}");
        }
    }
}
