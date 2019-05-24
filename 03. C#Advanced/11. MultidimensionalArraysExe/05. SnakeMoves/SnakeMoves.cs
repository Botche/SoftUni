using System;
using System.Linq;

namespace _5._SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constraits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string snake = Console.ReadLine();
            char[,] arr = new char[constraits[0], constraits[1]];

            int snakeLength = snake.Length;
            int counterSnakesLetters = 0;

            for (int row = 0; row < constraits[0]; row++)
            {
                for (int col = 0; col < constraits[1]; col++)
                {
                    if (counterSnakesLetters == snakeLength)
                        counterSnakesLetters = 0;
                    arr[row, col] = snake[counterSnakesLetters];
                    counterSnakesLetters++;
                }
            }

            for (int row = 0; row < constraits[0]; row++)
            {
                for (int col = 0; col < constraits[1]; col++)
                {
                    Console.Write(arr[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
