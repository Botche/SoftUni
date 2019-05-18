using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                int[] command = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int commandNumber = command[0];

                switch (commandNumber)
                {
                    case 1:
                        stack.Push(command[1]);
                        break;
                    case 2:
                        if (stack.Count != 0)
                            stack.Pop();
                        break;
                    case 3:
                        if (stack.Count != 0)
                            Console.WriteLine(stack.Max());
                        break;
                    case 4:
                        if (stack.Count != 0)
                            Console.WriteLine(stack.Min());
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
