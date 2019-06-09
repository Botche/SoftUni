using System;
using System.Linq;

namespace _3._PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[lengthOfMatrix, lengthOfMatrix];

            int sumOfPrimaryDiagonal = 0;

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < lengthOfMatrix; col++)
                {
                    matrix[row, col] = rowElements[col];

                    if (row == col)
                        sumOfPrimaryDiagonal += matrix[row, col];
                }
            }

            Console.WriteLine(sumOfPrimaryDiagonal);
        }
    }
}
