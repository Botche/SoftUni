using System;

namespace _02._TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfMatrix = int.Parse(Console.ReadLine());
            char[,] matrixField = new char[lengthOfMatrix, lengthOfMatrix];

            int[] coordinatesOfFirstPlayer = new int[2];
            int[] coordinatesOfSecondPlayer = new int[2];

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < lengthOfMatrix; col++)
                {
                    char ch = input[col];

                    if (ch == 'f')
                    {
                        coordinatesOfFirstPlayer[0] = row;
                        coordinatesOfFirstPlayer[1] = col;
                    }
                    else if (ch == 's')
                    {
                        coordinatesOfSecondPlayer[0] = row;
                        coordinatesOfSecondPlayer[1] = col;
                    }

                    matrixField[row, col] = ch;
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string commandForFirstPlayer = commands[0];
                string commandForSecondPlayer = commands[1];

                if (commandForFirstPlayer == "down")
                {
                    if (coordinatesOfFirstPlayer[0] + 1 == lengthOfMatrix)
                    {
                        coordinatesOfFirstPlayer[0] = 0;
                    }
                    else
                    {
                        coordinatesOfFirstPlayer[0]++;
                    }

                    if (matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]]
                            == '*')
                    {
                        matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]] = 'f';
                    }
                    else if (matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]]
                        == 's')
                    {
                        matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]] = 'x';
                        break;
                    }
                }
                else if (commandForFirstPlayer == "up")
                {
                    if (coordinatesOfFirstPlayer[0] - 1 < 0)
                    {
                        coordinatesOfFirstPlayer[0] = lengthOfMatrix - 1;
                    }
                    else
                    {
                        coordinatesOfFirstPlayer[0]--;
                    }

                    if (matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]]
                            == '*')
                    {
                        matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]] = 'f';
                    }
                    else if (matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]]
                        == 's')
                    {
                        matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]] = 'x';
                        break;
                    }
                }
                else if (commandForFirstPlayer == "left")
                {
                    if (coordinatesOfFirstPlayer[1] - 1 < 0)
                    {
                        coordinatesOfFirstPlayer[1] = lengthOfMatrix - 1;
                    }
                    else
                    {
                        coordinatesOfFirstPlayer[1]--;
                    }

                    if (matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]]
                        == '*')
                    {
                        matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]] = 'f';
                    }
                    else if (matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]]
                        == 's')
                    {
                        matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]] = 'x';
                        break;
                    }
                }
                else if (commandForFirstPlayer == "right")
                {
                    if (coordinatesOfFirstPlayer[1] + 1 == lengthOfMatrix)
                    {
                        coordinatesOfFirstPlayer[1] = 0;
                    }
                    else
                    {
                        coordinatesOfFirstPlayer[1]++;
                    }

                    if (matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]]
                        == '*')
                    {
                        matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]] = 'f';
                    }
                    else if (matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]]
                        == 's')
                    {
                        matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]] = 'x';
                        break;
                    }
                }

                if (commandForSecondPlayer == "down")
                {
                    if (coordinatesOfSecondPlayer[0] + 1 == lengthOfMatrix)
                    {
                        coordinatesOfSecondPlayer[0] = 0;
                    }
                    else
                    {
                        coordinatesOfSecondPlayer[0]++;
                    }

                    if (matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]]
                        == '*')
                    {
                        matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]] = 's';
                    }
                    else if (matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]]
                        == 'f')
                    {
                        matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]] = 'x';
                        break;
                    }
                }
                else if (commandForSecondPlayer == "up")
                {
                    if (coordinatesOfSecondPlayer[0] - 1 < 0)
                    {
                        coordinatesOfSecondPlayer[0] = lengthOfMatrix - 1;
                    }
                    else
                    {
                        coordinatesOfSecondPlayer[0]--;
                    }

                    if (matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]]
                        == '*')
                    {
                        matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]] = 's';
                    }
                    else if (matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]]
                        == 'f')
                    {
                        matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]] = 'x';
                        break;
                    }
                }
                else if (commandForSecondPlayer == "left")
                {
                    if (coordinatesOfSecondPlayer[1] - 1 < 0)
                    {
                        coordinatesOfSecondPlayer[1] = lengthOfMatrix - 1;
                    }
                    else
                    {
                        coordinatesOfSecondPlayer[1]--;
                    }

                    if (matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]]
                        == '*')
                    {
                        matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]] = 's';
                    }
                    else if (matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]]
                        == 'f')
                    {
                        matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]] = 'x';
                        break;
                    }
                }
                else if (commandForSecondPlayer == "right")
                {
                    if (coordinatesOfSecondPlayer[1] + 1 == lengthOfMatrix)
                    {
                        coordinatesOfSecondPlayer[1] = 0;
                    }
                    else
                    {
                        coordinatesOfSecondPlayer[1]++;
                    }

                    if (matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]]
                        == '*')
                    {
                        matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]] = 's';
                    }
                    else if (matrixField[coordinatesOfSecondPlayer[0], coordinatesOfSecondPlayer[1]]
                        == 'f')
                    {
                        matrixField[coordinatesOfFirstPlayer[0], coordinatesOfFirstPlayer[1]] = 'x';
                        break;
                    }
                }
            }

            for (int row = 0; row < lengthOfMatrix; row++)
            {
                for (int col = 0; col < lengthOfMatrix; col++)
                {
                    Console.Write(matrixField[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
