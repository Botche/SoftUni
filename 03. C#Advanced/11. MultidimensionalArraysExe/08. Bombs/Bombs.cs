using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[lengthOfMatrix, lengthOfMatrix];

            FillingMatrix(matrix);
            
            string[] coordinates = Console.ReadLine()
                .Split();

            foreach (var coordinate in coordinates)
            {
                int[] currentCoordinates = coordinate
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray();

                int currentRow = currentCoordinates[0];
                int currentCol = currentCoordinates[1];

                if (matrix[currentRow, currentCol] <= 0)
                {
                    continue;
                }

                int explosionDmg = matrix[currentRow, currentCol];
                matrix[currentRow, currentCol] = 0;

                KillingCells(currentRow, currentCol, matrix, explosionDmg);
            }

            PrintSumAndCountAliveCells(matrix);

            PrintMatrix(matrix);

        }

        private static void FillingMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void PrintSumAndCountAliveCells(int[,] matrix)
        {
            int sumOfAliveCells = 0;
            int countOfAliveCells = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sumOfAliveCells += matrix[row, col];
                        countOfAliveCells++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {countOfAliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");
        }
        private static void KillingCells(int currentRow, int currentCol, int[,] matrix, int explosionDmg)
        {
            for (int row = currentRow - 1; row <= currentRow + 1; row++)
            {
                for (int col = currentCol - 1; col <= currentCol + 1; col++)
                {
                    if (row >= 0 && row < matrix.GetLength(0)
                        && col >= 0 && col < matrix.GetLength(0))
                    {
                        if (matrix[row, col] > 0)
                            matrix[row, col] -= explosionDmg;
                    }
                }
            }
        }
    }
}
