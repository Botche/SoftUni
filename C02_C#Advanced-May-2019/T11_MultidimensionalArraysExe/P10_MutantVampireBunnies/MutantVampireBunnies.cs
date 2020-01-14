using System;
using System.Linq;

namespace _10._MutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] constraits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[constraits[0], constraits[1]];
            int[] coordinates = new int[2];

            for (int row = 0; row < constraits[0]; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < constraits[1]; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'P')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;
                    }
                }
            }
            string directions = Console.ReadLine();

            bool hasWon = false;
            bool hasLost = false;
            foreach (var direction in directions)
            {
                if (hasWon || hasLost)
                {
                    break;
                }
                //Moving
                switch (direction)
                {
                    case 'R':
                        if (coordinates[1] + 1 < constraits[1])
                        {
                            if (matrix[coordinates[0], coordinates[1] + 1] == 'B')
                            {
                                hasLost = true;
                            }
                            matrix[coordinates[0], coordinates[1]] = '.';
                            coordinates[1] += 1;
                            if (!hasLost)
                            {
                                matrix[coordinates[0], coordinates[1]] = 'P';
                            }
                        }
                        else
                        {
                            hasWon = true;
                            matrix[coordinates[0], coordinates[1]] = '.';
                        }
                        break;
                    case 'L':
                        if (coordinates[1] - 1 >= 0)
                        {
                            if (matrix[coordinates[0], coordinates[1] - 1] == 'B')
                            {
                                hasLost = true;
                            }
                            matrix[coordinates[0], coordinates[1]] = '.';
                            coordinates[1] -= 1;
                            if (!hasLost)
                            {
                                matrix[coordinates[0], coordinates[1]] = 'P';
                            }
                        }
                        else
                        {
                            hasWon = true;
                            matrix[coordinates[0], coordinates[1]] = '.';
                        }
                        break;
                    case 'U':
                        if (coordinates[0] - 1 >= 0)
                        {
                            if (matrix[coordinates[0] - 1, coordinates[1]] == 'B')
                            {
                                hasLost = true;
                            }
                            matrix[coordinates[0], coordinates[1]] = '.';
                            coordinates[0] -= 1;
                            if (!hasLost)
                            {
                                matrix[coordinates[0], coordinates[1]] = 'P';
                            }
                        }
                        else
                        {
                            hasWon = true;
                            matrix[coordinates[0], coordinates[1]] = '.';
                        }
                        break;
                    case 'D':
                        if (coordinates[0] + 1 < constraits[0])
                        {
                            if (matrix[coordinates[0] + 1, coordinates[1]] == 'B')
                            {
                                hasLost = true;
                            }
                            matrix[coordinates[0], coordinates[1]] = '.';
                            coordinates[0] += 1;
                            if (!hasLost)
                            {
                                matrix[coordinates[0], coordinates[1]] = 'P';
                            }
                        }
                        else
                        {
                            hasWon = true;
                            matrix[coordinates[0], coordinates[1]] = '.';
                        }
                        break;
                    default:
                        break;
                }
                //BunniesBouncing
                for (int row = 0; row < constraits[0]; row++)
                {
                    for (int col = 0; col < constraits[1]; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (row + 1 < constraits[0])
                            {
                                if (matrix[row + 1, col] != 'B')
                                {
                                    matrix[row + 1, col] = '?';
                                }
                            }
                            if (row - 1 >= 0)
                            {
                                if (matrix[row - 1, col] != 'B')
                                    matrix[row - 1, col] = '?';
                            }
                            if (col + 1 < constraits[1])
                            {
                                if (matrix[row , col+1] != 'B')
                                    matrix[row, col + 1] = '?';
                            }
                            if (col - 1 >= 0)
                            {
                                if (matrix[row, col - 1] != 'B')
                                    matrix[row, col - 1] = '?';
                            }
                        }
                    }
                }
                for (int row = 0; row < constraits[0]; row++)
                {
                    for (int col = 0; col < constraits[1]; col++)
                    {
                        if (matrix[row, col] == '?')
                        {
                            matrix[row, col] = 'B';
                        }
                    }
                }
                if (matrix[coordinates[0], coordinates[1]] == 'B')
                {
                    hasLost = true;
                }
            }
            //Output
            for (int row = 0; row < constraits[0]; row++)
            {
                for (int col = 0; col < constraits[1]; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            if (hasWon)
            {
                Console.WriteLine($"won: {coordinates[0]} {coordinates[1]}");
            }
            else
            {
                Console.WriteLine($"dead: {coordinates[0]} {coordinates[1]}");
            }
        }
    }
}
