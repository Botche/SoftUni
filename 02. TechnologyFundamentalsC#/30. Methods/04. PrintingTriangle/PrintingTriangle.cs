using System;

namespace printingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            PrintTriangle(length);
            PrintReverseTriangle(length);
        }

        private static void PrintReverseTriangle(int length)
        {
            for (int i = length - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintTriangle(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
