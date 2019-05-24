using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commandsToMove = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[fieldSize, fieldSize];

            int[] coordinates = new int[2];

            int countOfCoals=FillingField(field, coordinates);

            bool collectedCoals = false;
            bool endGame = false;
            foreach (var command in commandsToMove)
            {
                bool isMoved = CheckForMoving(command, coordinates, fieldSize);

                int rowIndex = coordinates[0];
                int colIndex = coordinates[1];

                if (isMoved)
                {
                    if (field[rowIndex, colIndex] == 'c')
                    {
                        countOfCoals--;
                        field[rowIndex, colIndex] = '*';
                        if (countOfCoals == 0)
                        {
                            collectedCoals = true;
                            break;
                        }
                    }
                    else if (field[rowIndex, colIndex] =='e')
                    {
                        endGame = true;
                        break;
                    }
                }
            }
            if (collectedCoals)
            {
                Console.WriteLine($"You collected all coals! ({coordinates[0]}, {coordinates[1]})");
            }
            else if(endGame)
            {
                Console.WriteLine($"Game over! ({coordinates[0]}, {coordinates[1]})");
            }
            else
            {
                Console.WriteLine($"{countOfCoals} coals left. ({coordinates[0]}, {coordinates[1]})");
            }
        }

        private static bool CheckForMoving(string command, int[] coordinates, int fieldSize)
        {
            bool isMoved = false;
            switch (command)
            {
                case "up":
                    if (coordinates[0] - 1 >= 0)
                    {
                        coordinates[0] -= 1;
                        isMoved = true;
                    }
                    else
                    {
                        isMoved = false;
                    }
                    break;
                case "down":
                    if (coordinates[0] + 1 < fieldSize)
                    {
                        coordinates[0] += 1;
                        isMoved = true;
                    }
                    else
                    {
                        isMoved = false;
                    }
                    break;
                case "left":
                    if (coordinates[1] - 1 >= 0)
                    {
                        coordinates[1] -= 1;
                        isMoved = true;
                    }
                    else
                    {
                        isMoved = false;
                    }
                    break;
                case "right":
                    if (coordinates[1] + 1 < fieldSize)
                    {
                        coordinates[1] += 1;
                        isMoved = true;
                    }
                    else
                    {
                        isMoved = false;
                    }
                    break;
                default:
                    break;
            }
            return isMoved;
        }

        private static int FillingField(char[,] field, int[] coordinates)
        {
            int count = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < field.GetLength(0); col++)
                {
                    field[row, col] = input[col];
                    if (input[col] == 'c')
                        count++;
                    if (input[col] =='s')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;
                    }
                }
            }
            return count;
        }
    }
}
