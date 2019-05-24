using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue =
                new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> evenNums = new Queue<int>();

            while(queue.Count>0)
            {
                if (queue.Peek() % 2 == 0)
                    evenNums.Enqueue(queue.Dequeue());
                else
                    queue.Dequeue();
            }

            Console.WriteLine(string.Join(", ",evenNums));
        }
    }
}
