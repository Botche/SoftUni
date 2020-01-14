using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>();

            foreach (var num in arr)
            {
                stack.Push(num);
            }

            string[] input = Console.ReadLine().Split();
            while (input[0].ToLower() != "end")
            {
                string command = input[0].ToLower();
                if (command == "add")
                {
                    int firstNum = int.Parse(input[1]);
                    int secondNum = int.Parse(input[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command == "remove")
                {
                    int length = int.Parse(input[1]);

                    if (length < stack.Count)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                input = Console.ReadLine().Split();
            }
            int sum = 0;
            foreach (var num in stack)
            {
                sum += num;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
