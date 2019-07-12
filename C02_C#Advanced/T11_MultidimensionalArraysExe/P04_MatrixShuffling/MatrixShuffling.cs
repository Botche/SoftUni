using System;
using System.Linq;

namespace _4._MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constraits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string[,] arr = new string[constraits[0], constraits[1]];

            for (int row = 0; row < constraits[0]; row++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                for (int col = 0; col < constraits[1]; col++)
                {
                    arr[row, col] = input[col];
                }
            }

            string[] commandInfo = Console.ReadLine()
                .Split();
            while (commandInfo[0] != "END")
            {
                if (commandInfo.Length >= 6
                    || commandInfo[0] != "swap"
                    || int.Parse(commandInfo[1]) < 0 || int.Parse(commandInfo[1]) >= constraits[0]
                    || int.Parse(commandInfo[2]) < 0 || int.Parse(commandInfo[2]) >= constraits[1]
                    || int.Parse(commandInfo[3]) < 0 || int.Parse(commandInfo[3]) >= constraits[0]
                    || int.Parse(commandInfo[4]) < 0 || int.Parse(commandInfo[4]) >= constraits[1])
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int firstCellRow = int.Parse(commandInfo[1]);
                    int firstCellCol = int.Parse(commandInfo[2]);
                    int secondCellRow = int.Parse(commandInfo[3]);
                    int secondCellCol = int.Parse(commandInfo[4]);

                    string numToSwap = arr[firstCellRow, firstCellCol];
                    arr[firstCellRow, firstCellCol]=arr[secondCellRow,secondCellCol];
                    arr[secondCellRow, secondCellCol]=numToSwap;

                    for (int row = 0; row < constraits[0]; row++)
                    {
                        for (int col = 0; col < constraits[1]; col++)
                        {
                            Console.Write(arr[row, col]+" ");
                        }
                        Console.WriteLine();
                    }
                }
                commandInfo = Console.ReadLine()
               .Split();
            }
        }
    }
}
