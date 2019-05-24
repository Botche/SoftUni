using System;
using System.Linq;

namespace _5._SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constraits = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] arrayOfNums = new int[constraits[0], constraits[1]];
            //Input
            for (int row = 0; row < constraits[0]; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < constraits[1]; col++)
                {
                    arrayOfNums[row, col] = input[col];
                }
            }
            //Do
            int maxSumOfTopLeftSquare = int.MinValue;
            int[,] squareWithMaxSum = new int[2, 2];
            for (int row = 0; row < constraits[0] - 1; row++)
            {
                for (int col = 0; col < constraits[1] - 1; col++)
                {
                    int sumOfSquare = 0;
                    sumOfSquare += arrayOfNums[row, col]
                        + arrayOfNums[row + 1, col]
                        + arrayOfNums[row, col + 1]
                        + arrayOfNums[row + 1, col + 1];
                    if (sumOfSquare>maxSumOfTopLeftSquare)
                    {
                        maxSumOfTopLeftSquare = sumOfSquare;
                        for (int i = 0; i < squareWithMaxSum.GetLength(0); i++)
                        {
                            for (int j = 0; j < squareWithMaxSum.GetLength(1); j++)
                            {
                                squareWithMaxSum[i, j] = arrayOfNums[row + i, col + j];
                            }
                        }
                    }
                }
            }
            //Output
            Console.WriteLine($"{squareWithMaxSum[0,0]} {squareWithMaxSum[0,1]}");
            Console.WriteLine($"{squareWithMaxSum[1,0]} {squareWithMaxSum[1,1]}");
            Console.WriteLine(maxSumOfTopLeftSquare);
        }
    }
}
