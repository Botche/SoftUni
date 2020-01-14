using System;

namespace _01._RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfRows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= countOfRows; i++)
            {
                printRow(i, countOfRows);
            }

            for (int i = countOfRows - 1; i >= 1; i--)
            {
                printRow(i, countOfRows);
            }
        }

        private static void printRow(int stars, int countOfRows)
        {
            int leadingSpaces = countOfRows - stars;

            Console.Write(new string(' ', leadingSpaces));

            for (int star = 0; star < stars; star++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
