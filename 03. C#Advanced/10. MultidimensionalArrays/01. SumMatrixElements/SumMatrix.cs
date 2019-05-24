using System;
using System.Linq;

namespace _01._SumMatrixElements
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

            int sumOfElements = 0;

            for (int row = 0; row < constraits[0]; row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < constraits[1]; col++)
                {
                    arrOfNums[row, col] = rowElements[col];
                    sumOfElements += rowElements[col];
                }
            }

            Console.WriteLine(arrOfNums.GetLength(0));
            Console.WriteLine(arrOfNums.GetLength(1));
            Console.WriteLine(sumOfElements);
        }
    }
}
