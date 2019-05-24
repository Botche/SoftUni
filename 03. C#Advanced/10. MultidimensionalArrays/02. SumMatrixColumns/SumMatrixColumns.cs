using System;
using System.Linq;

namespace _02._SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constraits = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] arrOfNums = new int[constraits[0], constraits[1]];

            int[] sumOfColumns = new int[constraits[1]];

            for (int row = 0; row < constraits[0]; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < constraits[1]; col++)
                {
                    arrOfNums[row, col] = input[col];
                    sumOfColumns[col] += input[col];
                }
            }

            foreach (var sum in sumOfColumns)
            {
                Console.WriteLine(sum);
            }
        }
    }
}
