using System;

namespace _02._HelenAbduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int lengthOfMatrix = int.Parse(Console.ReadLine());

            char[][] matrixField = new char[lengthOfMatrix][];
            int parisRow = 0;
            int parisCol = 0;
            for (int row = 0; row < lengthOfMatrix; row++)
            {
                string input = Console.ReadLine();
                matrixField[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrixField[row][col] = input[col];

                    if (matrixField[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }

            bool isHelenThere = false;
            while (energy > 0)
            {
                string[] commandInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandInput[0];
                int rowSpartan = int.Parse(commandInput[1]);
                int colSpartan = int.Parse(commandInput[2]);

                matrixField[rowSpartan][colSpartan] = 'S';

                energy--;

                switch (command)
                {
                    case "up":
                        if (parisRow > 0)
                        {
                            matrixField[parisRow][parisCol] = '-';
                            parisRow--;
                            if (matrixField[parisRow][parisCol] == 'S')
                            {
                                energy -= 2;
                            }
                            else if (matrixField[parisRow][parisCol] == 'H')
                            {
                                isHelenThere = true;
                                matrixField[parisRow][parisCol] = '-';
                                break;
                            }
                            matrixField[parisRow][parisCol] = 'P';
                        }
                        break;
                    case "down":
                        if (parisRow < lengthOfMatrix - 1)
                        {
                            matrixField[parisRow][parisCol] = '-';
                            parisRow++;
                            if (matrixField[parisRow][parisCol] == 'S')
                            {
                                energy -= 2;
                            }
                            else if (matrixField[parisRow][parisCol] == 'H')
                            {
                                isHelenThere = true;
                                matrixField[parisRow][parisCol] = '-';
                                break;
                            }
                            matrixField[parisRow][parisCol] = 'P';
                        }
                        break;
                    case "left":
                        if (parisCol > 0)
                        {
                            matrixField[parisRow][parisCol] = '-';
                            parisCol--;
                            if (matrixField[parisRow][parisCol] == 'S')
                            {
                                energy -= 2;
                            }
                            else if (matrixField[parisRow][parisCol] == 'H')
                            {
                                isHelenThere = true;
                                matrixField[parisRow][parisCol] = '-';
                                break;
                            }
                            matrixField[parisRow][parisCol] = 'P';
                        }
                        break;
                    case "right":
                        if (parisCol < lengthOfMatrix - 1)
                        {
                            matrixField[parisRow][parisCol] = '-';
                            parisCol++;
                            if (matrixField[parisRow][parisCol] == 'S')
                            {
                                energy -= 2;
                            }
                            else if (matrixField[parisRow][parisCol] == 'H')
                            {
                                isHelenThere = true;
                                matrixField[parisRow][parisCol] = '-';
                                break;
                            }
                            matrixField[parisRow][parisCol] = 'P';
                        }
                        break;
                    default:
                        break;
                }
                if (isHelenThere)
                {
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    break;
                }
            }

            if (energy <= 0 && !isHelenThere)
            {
                matrixField[parisRow][parisCol] = 'X';
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                for (int col = 0; col < matrixField[row].Length; col++)
                {
                    Console.Write(matrixField[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
