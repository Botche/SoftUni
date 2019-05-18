using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>();

            int length = nums[0];
            int countToDelete = nums[1];
            int numToFInd = nums[2];

            for (int i = 0; i < length; i++)
            {
                queue.Enqueue(input[i]);
            }

            for (int i = 0; i < countToDelete; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numToFInd))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    int min = int.MaxValue;
                    while (queue.Count != 0)
                    {
                        if (queue.Peek() < min)
                            min = queue.Peek();
                        queue.Dequeue();
                    }
                    Console.WriteLine(min);
                }
            }
        }
    }
}
