using System;

namespace _03._SpaceStationEstablisment
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int lengthOfMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[lengthOfMatrix, lengthOfMatrix];

            int[] coordinatesS = new int[2];

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < lengthOfMatrix; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        coordinatesS[0] = row;
                        coordinatesS[1] = col;
                    }

                }
            }
            bool isBuilt = false;
            int sumOfStarPower = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "right")
                {
                    if (coordinatesS[1] + 1 >= lengthOfMatrix)
                    {
                        matrix[coordinatesS[0], coordinatesS[1]] = '-';
                        break;
                    }
                    matrix[coordinatesS[0], coordinatesS[1]] = '-';
                    coordinatesS[1]++;
                    if (char.IsDigit(matrix[coordinatesS[0], coordinatesS[1]]))
                    {
                        sumOfStarPower += matrix[coordinatesS[0], coordinatesS[1]] - 48;
                    }
                    else if (matrix[coordinatesS[0], coordinatesS[1]] == 'O')
                    {
                        matrix[coordinatesS[0], coordinatesS[1]] = '-';
                        for (int row = 0; row < lengthOfMatrix; row++)
                        {
                            for (int col = 0; col < lengthOfMatrix; col++)
                            {
                                if (matrix[row, col] == 'O'
                                    && row!= coordinatesS[0] && col!=coordinatesS[1])
                                {
                                    coordinatesS[0] = row;
                                    coordinatesS[1] = col;
                                    break;
                                }
                            }
                        }
                    }

                    matrix[coordinatesS[0], coordinatesS[1]] = 'S';
                }
                else if (input == "left")
                {
                    if (coordinatesS[1] - 1 < 0)
                    {
                        matrix[coordinatesS[0], coordinatesS[1]] = '-';
                        break;
                    }
                    matrix[coordinatesS[0], coordinatesS[1]] = '-';
                    coordinatesS[1]--;
                    if (char.IsDigit(matrix[coordinatesS[0], coordinatesS[1]]))
                    {
                        sumOfStarPower += matrix[coordinatesS[0], coordinatesS[1]] - 48;
                    }
                    else if (matrix[coordinatesS[0], coordinatesS[1]] == 'O')
                    {
                        for (int row = 0; row < lengthOfMatrix; row++)
                        {
                            for (int col = 0; col < lengthOfMatrix; col++)
                            {
                                if (matrix[coordinatesS[0], coordinatesS[1]] == 'O'
                                    && row != coordinatesS[0] && col != coordinatesS[1])
                                {
                                    coordinatesS[0] = row;
                                    coordinatesS[1] = col;
                                }
                            }
                        }
                    }

                    matrix[coordinatesS[0], coordinatesS[1]] = 'S';
                }
                else if (input == "up")
                {
                    if (coordinatesS[0] - 1 < 0)
                    {
                        matrix[coordinatesS[0], coordinatesS[1]] = '-';
                        break;
                    }
                    matrix[coordinatesS[0], coordinatesS[1]] = '-';
                    coordinatesS[0]--;
                    if (char.IsDigit(matrix[coordinatesS[0], coordinatesS[1]]))
                    {
                        sumOfStarPower += matrix[coordinatesS[0], coordinatesS[1]] - 48;
                    }
                    else if (matrix[coordinatesS[0], coordinatesS[1]] == 'O')
                    {
                        for (int row = 0; row < lengthOfMatrix; row++)
                        {
                            for (int col = 0; col < lengthOfMatrix; col++)
                            {
                                if (matrix[coordinatesS[0], coordinatesS[1]] == 'O'
                                    && row != coordinatesS[0] && col != coordinatesS[1])
                                {
                                    coordinatesS[0] = row;
                                    coordinatesS[1] = col;
                                }
                            }
                        }
                    }

                    matrix[coordinatesS[0], coordinatesS[1]] = 'S';
                }
                else if (input == "down")
                {
                    if (coordinatesS[0] + 1 >= lengthOfMatrix)
                    {
                        matrix[coordinatesS[0], coordinatesS[1]] = '-';
                        break;
                    }
                    matrix[coordinatesS[0], coordinatesS[1]] = '-';
                    coordinatesS[0]++;
                    if (char.IsDigit(matrix[coordinatesS[0], coordinatesS[1]]))
                    {
                        sumOfStarPower += matrix[coordinatesS[0], coordinatesS[1]] - 48;
                    }
                    else if (matrix[coordinatesS[0], coordinatesS[1]] == 'O')
                    {
                        for (int row = 0; row < lengthOfMatrix; row++)
                        {
                            for (int col = 0; col < lengthOfMatrix; col++)
                            {
                                if (matrix[coordinatesS[0], coordinatesS[1]] == 'O'
                                    && row != coordinatesS[0] && col != coordinatesS[1])
                                {
                                    coordinatesS[0] = row;
                                    coordinatesS[1] = col;
                                }
                            }
                        }
                    }

                    matrix[coordinatesS[0], coordinatesS[1]] = 'S';
                }

                if (sumOfStarPower>=50)
                {
                    isBuilt = true;
                    break;
                }
            }

            if (isBuilt)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }

            Console.WriteLine($"Star power collected: {sumOfStarPower}");

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                for (int col = 0; col < lengthOfMatrix; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
