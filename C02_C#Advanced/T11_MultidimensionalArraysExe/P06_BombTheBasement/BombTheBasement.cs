using System;
using System.Linq;

namespace _6._BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constraits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[,] array = new int[constraits[0], constraits[1]];

            for (int row = 0; row < constraits[0]; row++)
            {
                for (int col = 0; col < constraits[1]; col++)
                {
                    array[row, col] = 0;
                }
            }

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bombRow = input[0];
            int bombCol = input[1];
            int radiusOfBombExpl = input[2];

            int counter = 0;
            for (int row = bombRow - radiusOfBombExpl; row <= bombRow; row++)
            {
                for (int col = bombCol - counter; col <= bombCol + counter; col++)
                {
                    if (row >= 0 && row < constraits[0]
                    && col >= 0 && col < constraits[1])
                    {
                        array[row, col] = 1;
                    }
                }
                counter++;
            }
            counter-=2;
            for (int row = bombRow + 1; row <= bombRow + radiusOfBombExpl; row++)
            {
                for (int col = bombCol - counter; col <= bombCol + counter; col++)
                {
                    if (row >= 0 && row < constraits[0]
                    && col >= 0 && col < constraits[1])
                    {
                        array[row, col] = 1;
                    }
                }
                counter--;
            }
            for (int row = 0; row < constraits[0] - 1; row++)
            {
                for (int col = 0; col < constraits[1]; col++)
                {
                    if (array[row + 1, col] == 1 && array[row, col] == 0)
                    {
                        array[row + 1, col] = 0;
                        array[row, col] = 1;

                        if (row > 2)
                            row -= 2;
                        else
                            row = -1;
                        break;
                    }
                }
            }
            for (int row = 0; row < constraits[0]; row++)
            {
                for (int col = 0; col < constraits[1]; col++)
                {
                    Console.Write(array[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
