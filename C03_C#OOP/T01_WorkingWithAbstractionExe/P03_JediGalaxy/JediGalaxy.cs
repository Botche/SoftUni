using System;
using System.Linq;

namespace _03._JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = InputParse();

            int firstDemestion = dimestions[0];
            int secondDemestion = dimestions[1];

            int[,] matrix = new int[firstDemestion, secondDemestion];

            FillMatrix(matrix);

            string command = null;
            long sum = 0;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoCoordinates = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] evilCoordinates = InputParse();

                EvilMoving(matrix,evilCoordinates);

                sum += IvoMoving(matrix, ivoCoordinates,sum);
                
            }

            Console.WriteLine(sum);

        }

        private static long IvoMoving(int[,] matrix, int[] ivoCoordinates, long sum)
        {
            int ivoRow = ivoCoordinates[0];
            int ivoCol = ivoCoordinates[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 && ivoRow < matrix.GetLength(0)
                    && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return sum;
        }

        private static void EvilMoving(int[,] matrix,int[] evilCoordinates)
        {
            int evilRow = evilCoordinates[0];
            int evilCol = evilCoordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0)
                    && evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private static int[] InputParse()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static void FillMatrix(int[,] matrix)
        {
            int value = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }
    }
}
