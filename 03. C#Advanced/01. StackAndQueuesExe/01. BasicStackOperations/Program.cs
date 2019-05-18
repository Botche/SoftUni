using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>();

            int length = nums[0];
            int numbersToDelete = nums[1];
            int numberToFind = nums[2];

            for (int i = 0; i < length; i++)
            {
                stack.Push(arr[i]);
            }

            for (int i = 0; i < numbersToDelete; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numberToFind))
                Console.WriteLine("true");
            else
            {
                int min = int.MaxValue;
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    while (stack.Count != 0)
                    {
                        if (min > stack.Peek())
                            min = stack.Peek();
                        stack.Pop();
                    }
                    Console.WriteLine(min);
                }
            }
        }
    }
}
