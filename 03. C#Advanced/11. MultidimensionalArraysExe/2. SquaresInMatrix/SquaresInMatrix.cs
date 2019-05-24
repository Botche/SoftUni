using System;
using System.Linq;

namespace _2._SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constraits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            char[,] array = new char[constraits[0], constraits[1]];

            for (int row = 0; row < constraits[0]; row++)
            {
                char[] input = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < constraits[1]; col++)
                {
                    array[row, col] = input[col];
                }
            }

            int counterOfEqualSqares = 0;

            for (int row = 0; row < constraits[0] - 1; row++)
            {
                for (int col = 0; col < constraits[1] - 1; col++)
                {
                    if (array[row, col] == array[row, col + 1] 
                        && array[row, col] == array[row + 1, col]
                        && array[row, col] == array[row + 1, col + 1])
                    {
                        counterOfEqualSqares++;
                    }
                }
            }

            Console.WriteLine(counterOfEqualSqares);
        }
    }
}
