using System;

namespace P06_Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfRows = int.Parse(Console.ReadLine());

            string lineInput = Console.ReadLine();

            char[,] field = new char[countOfRows, lineInput.Length];
            int[] coordinatesOfSam = new int[2];
            int[] coordinatesOfNiko = new int[2];
            for (int row = 0; row < countOfRows; row++)
            {
                for (int col = 0; col < lineInput.Length; col++)
                {
                    field[row, col] = lineInput[col];

                    if (lineInput[col] == 'S')
                    {
                        coordinatesOfSam[0] = row;
                        coordinatesOfSam[1] = col;
                    }
                    else if (lineInput[col] == 'N')
                    {
                        coordinatesOfNiko[0] = row;
                        coordinatesOfNiko[1] = col;
                    }
                }
                if (row != countOfRows - 1)
                {
                    lineInput = Console.ReadLine();
                }
            }

            string directions = Console.ReadLine();
            bool isSamAlive = true;
            bool isNikoAlive = true;
            foreach (var direction in directions)
            {
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        if (field[row, col] == 'b')
                        {
                            if (col + 1 == field.GetLength(1))
                            {
                                field[row, col] = 'd';
                                for (int colOfEnemy = col; colOfEnemy >= 0; colOfEnemy--)
                                {
                                    if (row == coordinatesOfSam[0] && col == coordinatesOfSam[1])
                                    {
                                        field[coordinatesOfSam[0], coordinatesOfSam[1]] = 'X';
                                        isSamAlive = false;
                                    }
                                }
                            }
                            else
                            {
                                field[row, col + 1] = 'b';
                                field[row, col] = '.';
                                col++;

                                for (int colOfEnemy = col; colOfEnemy < field.GetLength(1); colOfEnemy++)
                                {
                                    if (row == coordinatesOfSam[0] && colOfEnemy == coordinatesOfSam[1])
                                    {
                                        field[coordinatesOfSam[0], coordinatesOfSam[1]] = 'X';
                                        isSamAlive = false;
                                    }
                                }
                            }
                        }
                        else if (field[row, col] == 'd')
                        {
                            if (col - 1 < 0)
                            {
                                field[row, col] = 'b';
                                for (int colOfEnemy = col; colOfEnemy < field.GetLength(1); colOfEnemy++)
                                {
                                    if (row == coordinatesOfSam[0] && colOfEnemy == coordinatesOfSam[1])
                                    {
                                        field[coordinatesOfSam[0], coordinatesOfSam[1]] = 'X';
                                        isSamAlive = false;
                                    }
                                }
                            }
                            else
                            {
                                field[row, col - 1] = 'd';
                                field[row, col] = '.';

                                for (int colOfEnemy = col; colOfEnemy >= 0; colOfEnemy--)
                                {
                                    if (row == coordinatesOfSam[0] && col == coordinatesOfSam[1])
                                    {
                                        field[coordinatesOfSam[0], coordinatesOfSam[1]] = 'X';
                                        isSamAlive = false;
                                    }
                                }
                            }
                        }
                    }
                }
                if (!isSamAlive)
                {
                    break;
                }
                switch (direction)
                {
                    case 'U':
                        coordinatesOfSam[0]--;
                        if (coordinatesOfSam[0] == coordinatesOfNiko[0])
                        {
                            isNikoAlive = false;
                            field[coordinatesOfNiko[0], coordinatesOfNiko[1]] = 'X';
                        }
                        field[coordinatesOfSam[0], coordinatesOfSam[1]] = 'S';
                        field[coordinatesOfSam[0] + 1, coordinatesOfSam[1]] = '.';
                        break;
                    case 'D':
                        coordinatesOfSam[0]++;
                        if (coordinatesOfSam[0] == coordinatesOfNiko[0])
                        {
                            isNikoAlive = false;
                            field[coordinatesOfNiko[0], coordinatesOfNiko[1]] = 'X';
                        }
                        field[coordinatesOfSam[0], coordinatesOfSam[1]] = 'S';
                        field[coordinatesOfSam[0] - 1, coordinatesOfSam[1]] = '.';
                        break;
                    case 'L':
                        coordinatesOfSam[1]--;
                        if (coordinatesOfSam[0] == coordinatesOfNiko[0])
                        {
                            isNikoAlive = false;
                            field[coordinatesOfNiko[0], coordinatesOfNiko[1]] = 'X';
                        }
                        field[coordinatesOfSam[0], coordinatesOfSam[1]] = 'S';
                        field[coordinatesOfSam[0], coordinatesOfSam[1] + 1] = '.';
                        break;
                    case 'R':
                        coordinatesOfSam[1]++;
                        if (coordinatesOfSam[0] == coordinatesOfNiko[0])
                        {
                            isNikoAlive = false;
                            field[coordinatesOfNiko[0], coordinatesOfNiko[1]] = 'X';
                        }
                        field[coordinatesOfSam[0], coordinatesOfSam[1]] = 'S';
                        field[coordinatesOfSam[0], coordinatesOfSam[1] - 1] = '.';
                        break;
                    default:
                        break;
                }
                if (!isNikoAlive)
                {
                    break;
                }
            }

            if (isNikoAlive)
            {
                Console.WriteLine($"Sam died at {coordinatesOfSam[0]}, {coordinatesOfSam[1]}");
            }
            else
            {
                Console.WriteLine("Nikoladze killed!");
            }
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }

        }
    }
}
