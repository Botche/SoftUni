using System;

namespace _7._PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfPascalTriangle = int.Parse(Console.ReadLine());
            long[,] matrixOfPascal = new long[lengthOfPascalTriangle, lengthOfPascalTriangle];


            for (int row = 0; row < lengthOfPascalTriangle; row++)
            {
                matrixOfPascal[row, 0] = 1;
            }

            for (int row = 1; row < lengthOfPascalTriangle; row++)
            {
                for (int col = 1; col < lengthOfPascalTriangle; col++)
                {
                    matrixOfPascal[row, col] = matrixOfPascal[row - 1, col - 1] + matrixOfPascal[row - 1, col];
                }
            }

            for (int row = 0; row < lengthOfPascalTriangle; row++)
            {
                for (int col = 0; col < lengthOfPascalTriangle; col++)
                {
                    if (matrixOfPascal[row, col] != 0)
                        Console.Write(matrixOfPascal[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
