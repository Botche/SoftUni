using System;
using System.Linq;

namespace _6._JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixLength = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixLength, matrixLength];

            for (int row = 0; row < matrixLength; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrixLength; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string[] commandInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (commandInfo[0].ToLower()!="end")
            {
                string command = commandInfo[0];
                int row = int.Parse(commandInfo[1]);
                int col = int.Parse(commandInfo[2]);
                int value = int.Parse(commandInfo[3]);

                if(row>=matrixLength || row<0
                    || col>=matrixLength || col<0)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (command.ToLower() == "add")
                    {
                        matrix[row, col] += value;
                    }
                    else if (command.ToLower()== "subtract")
                    {
                        matrix[row, col] -= value;
                    }
                }
                commandInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            for (int row = 0; row < matrixLength; row++)
            {
                for (int col = 0; col < matrixLength; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
