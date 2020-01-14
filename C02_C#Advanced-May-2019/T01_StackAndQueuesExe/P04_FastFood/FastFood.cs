using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Queue<int> orders = new Queue<int>(input);

            int maxFood = orders.Max();
            while (orders.Count!=0)
            {
                int food = orders.Peek();

                if(quantityOfFood>=food)
                {
                    quantityOfFood -= food;
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(maxFood);

            if (orders.Count==0)
                Console.WriteLine("Orders complete");
            else
                Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
        }
    }
}
