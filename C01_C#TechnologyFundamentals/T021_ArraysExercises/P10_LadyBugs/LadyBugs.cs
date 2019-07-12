using System;
using System.Linq;

namespace ladyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int[] ladyBugs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            int[] field = new int[sizeOfField];
            for (int i = 0; i < field.Length; i++)
            {
                if (ladyBugs.Contains(i))
                    field[i] = 1;
                else
                    field[i] = 0;
            }

            while (command[0] != "end")
            {
                int ladyBugIndex = int.Parse(command[0]);
                string direction = command[1];
                int flyLength = int.Parse(command[2]);
                if (ladyBugIndex < 0 || ladyBugIndex >= field.Length)
                {
                    command = Console.ReadLine().Split();
                    continue;
                }
                else if (field[ladyBugIndex] == 0)
                {
                    command = Console.ReadLine().Split();
                    continue;
                }
                else if (field[ladyBugIndex] == 1)
                {
                    if (direction == "right")
                    {
                        field[ladyBugIndex] = 0;
                        for (int i = ladyBugIndex + flyLength; i < field.Length; i += flyLength)
                        {
                            if (field[i] == 1)
                            {
                                continue;
                            }

                            else
                            {
                                field[i] = 1;
                                break;
                            }

                        }
                    }
                    else
                    {
                        field[ladyBugIndex] = 0;
                        for (int i = ladyBugIndex - flyLength; i >= 0; i -= flyLength)
                        {
                            if (field[i] == 1)
                            {
                                continue;
                            }

                            else
                            {
                                field[i] = 1;
                                break;
                            }

                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            for (int i = 0; i < field.Length; i++)
            {
                Console.Write(field[i] + " ");
            }
        }
    }
}
