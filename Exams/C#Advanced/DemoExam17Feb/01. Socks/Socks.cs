using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Socks
{
    class Socks
    {
        static void Main(string[] args)
        {
            int[] firstLineInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] secondLineInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> rightSocks = new Queue<int>();

            for (int i = 0; i < secondLineInput.Length; i++)
            {
                rightSocks.Enqueue(secondLineInput[i]);
            }

            Stack<int> leftSocks = new Stack<int>();

            for (int i = 0; i < firstLineInput.Length; i++)
            {
                leftSocks.Push(firstLineInput[i]);
            }

            List<int> pairs = new List<int>();

            while (leftSocks.Count != 0 && rightSocks.Count != 0)
            {
                int leftSock = leftSocks.Peek();
                int rightSock = rightSocks.Peek();

                if (leftSock > rightSock)
                {
                    pairs.Add(leftSock + rightSock);

                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
                else if (leftSock < rightSock)
                {
                    leftSocks.Pop();
                }
                else if (leftSock == rightSock)
                {
                    leftSock++;

                    leftSocks.Pop();
                    leftSocks.Push(leftSock);

                    rightSocks.Dequeue(); 
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
