using System;
using System.Linq;

namespace _1._DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[lengthOfMatrix, lengthOfMatrix];

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < lengthOfMatrix; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sumOfPrimaryDiagonal = 0;
            int sumOfSecondPrimaryDiagonal = 0;

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                for (int col = 0; col < lengthOfMatrix; col++)
                {
                    if (row==col)
                    {
                        sumOfPrimaryDiagonal += matrix[row, col];
                    }
                    if (row+col==lengthOfMatrix-1)
                    {
                        sumOfSecondPrimaryDiagonal += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumOfPrimaryDiagonal-sumOfSecondPrimaryDiagonal));
        }
    }
}
