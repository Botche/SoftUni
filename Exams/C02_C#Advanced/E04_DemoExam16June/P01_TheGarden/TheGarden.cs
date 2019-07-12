using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfRows = int.Parse(Console.ReadLine());

            char[][] field = new char[lengthOfRows][];

            for (int row = 0; row < lengthOfRows; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                field[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    field[row][col] = input[col];
                }
            }
            string[] commandInput = new string[4];
            var counters = new Dictionary<char, int>();
            counters.Add(' ', 0);
            counters.Add('C', 0);
            counters.Add('L', 0);
            counters.Add('P', 0);
            while ((commandInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries))[0].ToLower() != "end")
            {
                string command = commandInput[0].ToLower();
                int firstIndex = int.Parse(commandInput[1]);
                int secondIndex = int.Parse(commandInput[2]);

                if (firstIndex < lengthOfRows && firstIndex >= 0
               && secondIndex < field[firstIndex].Length && secondIndex >= 0)
                {
                    if (command == "harvest")
                    {
                        if (field[firstIndex][secondIndex] != ' ')
                        {
                            counters[field[firstIndex][secondIndex]]++;

                            field[firstIndex][secondIndex] = ' ';
                        }

                    }
                    else
                    {
                        string direction = commandInput[3];
                        switch (direction)
                        {
                            case "up":
                                while (firstIndex >= 0)
                                {
                                    if (field[firstIndex][secondIndex] != ' ')
                                    {
                                        field[firstIndex][secondIndex] = ' ';
                                        counters[field[firstIndex][secondIndex]]++;
                                    }
                                    firstIndex -= 2;
                                }
                                break;
                            case "down":
                                while (firstIndex < lengthOfRows)
                                {
                                    if (field[firstIndex][secondIndex] != ' ')
                                    {
                                        field[firstIndex][secondIndex] = ' ';
                                        counters[field[firstIndex][secondIndex]]++;
                                    }

                                    firstIndex += 2;
                                }
                                break;
                            case "left":
                                while (secondIndex >= 0)
                                {
                                    if (field[firstIndex][secondIndex] != ' ')
                                    {
                                        field[firstIndex][secondIndex] = ' ';
                                        counters[field[firstIndex][secondIndex]]++;
                                    }

                                    secondIndex -= 2;
                                }
                                break;
                            case "right":
                                while (secondIndex < field[firstIndex].Length)
                                {
                                    if (field[firstIndex][secondIndex] != ' ')
                                    {
                                        field[firstIndex][secondIndex] = ' ';
                                        counters[field[firstIndex][secondIndex]]++;

                                    }
                                    secondIndex += 2;
                                }
                                break;
                        }
                    }
                }
            }


            for (int row = 0; row < lengthOfRows; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (col == field[row].Length - 1)
                    {
                        Console.Write(field[row][col]);
                    }
                    else
                    {
                        Console.Write(field[row][col] + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Carrots: {counters['C']}");
            Console.WriteLine($"Potatoes: {counters['P']}");
            Console.WriteLine($"Lettuce: {counters['L']} ");
            Console.WriteLine($"Harmed vegetables: {counters[' ']}");

        }
    }
}