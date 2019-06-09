using System;
using System.Linq;

namespace _02._ExcelFunctions
{
    class ExcelFunctions
    {
        static void Main(string[] args)
        {
            int lengthOfRows = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int lengthOfColumns = input.Length;
            string[,] arr = new string[lengthOfRows, lengthOfColumns];
            for (int row = 0; row < lengthOfRows; row++)
            {
                for (int col = 0; col < lengthOfColumns; col++)
                {
                    arr[row, col] = input[col];
                }
                if (row != lengthOfRows - 1)
                {
                    input = Console.ReadLine()
                       .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                }
            }

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (command[0] == "hide")
            {
                string header = command[1];
                for (int col = 0; col < lengthOfColumns; col++)
                {
                    int row = 0;
                    if (arr[row, col] == header)
                    {
                        ShiftLeft(col, lengthOfRows, lengthOfColumns, arr);
                        lengthOfColumns--;
                        break;
                    }
                }
                for (int i = 0; i < lengthOfRows; i++)
                {
                    for (int j = 0; j < lengthOfColumns; j++)
                    {
                        if (j == lengthOfColumns - 1)
                        {
                            Console.Write(arr[i, j]);
                        }
                        else
                        {
                            Console.Write($"{arr[i, j]} | ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else if (command[0] == "sort")
            {
                string header = command[1];
                int mainCol = 0;
                for (int col = 0; col < lengthOfColumns; col++)
                {
                    int row = 0;
                    if (arr[row, col] == header)
                    {
                        mainCol = col;
                        break;
                    }
                }
                for (int i = 1; i < lengthOfRows; i++)
                {
                    for (int row = i; row < lengthOfRows - 1; row++)
                    {
                        int col = mainCol;
                        if (arr[row, col][0] > arr[row + 1, col][0])
                        {
                            for (int coll = 0; coll < lengthOfColumns; coll++)
                            {
                                var variable = arr[row, coll];
                                arr[row, coll] = arr[row + 1, coll];
                                arr[row + 1, coll] = variable;
                            }
                        }
                    }
                }
                for (int i = 0; i < lengthOfRows; i++)
                {
                    for (int j = 0; j < lengthOfColumns; j++)
                    {
                        if (j == lengthOfColumns - 1)
                        {
                            Console.Write(arr[i, j]);
                        }
                        else
                        {
                            Console.Write($"{arr[i, j]} | ");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int coll = 0; coll < lengthOfColumns; coll++)
                {
                    int row = 0;
                    if (coll == lengthOfColumns - 1)
                    {
                        Console.Write(arr[row, coll]);
                    }
                    else
                    {
                        Console.Write($"{arr[row, coll]} | ");
                    }

                }
                Console.WriteLine();
                string header = command[1];
                string str = command[2];

                int col = 0;
                for (int coll = 0; coll < lengthOfColumns; coll++)
                {
                    int row = 0;
                    if (arr[row, coll] == header)
                    {
                        col = coll;
                        break;
                    }
                }

                for (int row = 0; row < lengthOfRows; row++)
                {
                    if (arr[row, col] == str)
                    {
                        for (int coll = 0; coll < lengthOfColumns; coll++)
                        {
                            if (coll == lengthOfColumns - 1)
                            {
                                Console.Write(arr[row, coll]);
                            }
                            else
                            {
                                Console.Write($"{arr[row, coll]} | ");
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void ShiftLeft(int column, int lengthOfRows, int lengthOfColumns, string[,] arr)
        {
            for (int col = column; col < lengthOfColumns - 1; col++)
            {
                for (int row = 0; row < lengthOfRows; row++)
                {
                    arr[row, col] = arr[row, col + 1];
                }
            }
            for (int row = 0; row < lengthOfRows; row++)
            {
                int col = lengthOfColumns - 1;
                arr[row, col] = null;
            }
        }
    }
}
