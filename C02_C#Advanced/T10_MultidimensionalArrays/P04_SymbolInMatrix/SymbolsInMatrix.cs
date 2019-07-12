using System;
using System.Linq;

namespace _4._SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfMatrix = int.Parse(Console.ReadLine());
            char[,] matrixOfSymbols = new char[lengthOfMatrix, lengthOfMatrix];

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                string inputOfSymbols = Console.ReadLine();
                for (int col = 0; col < lengthOfMatrix; col++)
                {
                    matrixOfSymbols[row, col] = inputOfSymbols[col];
                }
            }

            char symbolToBeFound = char.Parse(Console.ReadLine());
            int[] coordinatesOfSymbol = new int[2];

            bool isContained = false;

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                for (int col = 0; col < lengthOfMatrix; col++)
                {
                    if(matrixOfSymbols[row,col]==symbolToBeFound)
                    {
                        coordinatesOfSymbol[0] = row;
                        coordinatesOfSymbol[1] = col;
                        isContained = true;
                        break;
                    }
                }
                if (isContained)
                {
                    break;
                }
            }

            if (isContained)
            {
                Console.WriteLine($"({coordinatesOfSymbol[0]}, {coordinatesOfSymbol[1]})");
            }
            else
            {
                Console.WriteLine($"{symbolToBeFound} does not occur in the matrix");
            }
        }
    }
}
