using System;
using System.Linq;

namespace _3._MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constraits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[,] array = new int[constraits[0], constraits[1]];

            for (int row = 0; row < constraits[0]; row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < constraits[1]; col++)
                {
                    array[row, col] = input[col];
                }
            }

            int maxSumOfSquare = int.MinValue;
            int currentRow = 0;
            int currentCol = 0;

            for (int row = 0; row < constraits[0] - 2; row++)
            {
                for (int col = 0; col < constraits[1] - 2; col++)
                {
                    int sum = array[row, col] + array[row, col + 1] + array[row, col + 2]
                        + array[row + 1, col] + array[row + 1, col + 1] + array[row + 1, col + 2]
                        + array[row + 2, col] + array[row + 2, col + 1] + array[row + 2, col + 2];

                    if (maxSumOfSquare < sum)
                    {
                        maxSumOfSquare = sum;
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSumOfSquare}");
            for (int row = currentRow; row < currentRow+3; row++)
            {
                for (int col = currentCol; col < currentCol+ 3; col++)
                {
                    Console.Write(array[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
