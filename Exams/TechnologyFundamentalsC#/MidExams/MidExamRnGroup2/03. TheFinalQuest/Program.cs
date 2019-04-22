using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Stop")
            {
                switch (command[0])
                {
                    case "Delete":
                        int index = int.Parse(command[1]);
                        if (index + 1 < input.Count && index + 1 >= 0)
                            input.RemoveAt(index + 1);
                        break;
                    case "Swap":
                        string firstWord = command[1];
                        string secondWord = command[2];

                        if (input.Contains(firstWord) && input.Contains(secondWord))
                        {
                            int secondIndex = input.IndexOf(secondWord);
                            int firstIndex = input.IndexOf(firstWord);
                            input.Insert(firstIndex, secondWord);
                            input.RemoveAt(firstIndex + 1);

                            input.Insert(secondIndex, firstWord);
                            input.RemoveAt(secondIndex + 1);
                        }
                        break;

                    case "Put":
                        string word = command[1];
                        index = int.Parse(command[2]);

                        if (index <= input.Count + 1 && index > 0)
                        {
                            input.Insert(index - 1, word);
                        }

                        break;
                    case "Sort":
                        input.Sort();
                        input.Reverse();
                        break;
                    case "Replace":
                        firstWord = command[1];
                        secondWord = command[2];

                        if (input.Contains(secondWord))
                        {
                            index = input.IndexOf(secondWord);
                            input.Insert(index, firstWord);
                            input.Remove(secondWord);
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
