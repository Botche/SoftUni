using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < length; i++)
            {
                int[] pertrolInfo = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(pertrolInfo);
            }

            
            for (int i = 0; i < length; i++)
            {
                bool isSuccessed = true;
                int petrolSum = 0;
                foreach (var fuel in queue)
                { 
                    int[] petrolInfo = fuel;

                    int petrol = petrolInfo[0];
                    int kms = petrolInfo[1];

                    petrolSum += petrol;
                    petrolSum -= kms;

                    if (petrolSum < 0)
                    {
                        isSuccessed = false;
                        break;
                    }
                }

                if (isSuccessed)
                {
                    Console.WriteLine(i);
                    break;
                }

                queue.Enqueue(queue.Dequeue());
            }
        }
    }
}
