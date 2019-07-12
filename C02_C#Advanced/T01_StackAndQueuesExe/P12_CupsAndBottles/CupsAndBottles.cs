using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int[] filledBottles = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacity);
            Stack<int> bottles = new Stack<int>(filledBottles);

            int wastedLitters = 0;

            int cup = cups.Peek();
            while (cups.Count!=0 && bottles.Count!=0)
            {
                int bottle = bottles.Peek();

                if (bottle >= cup)
                {
                    wastedLitters += bottle - cup;
                    cups.Dequeue();
                    bottles.Pop();
                    if (cups.Count == 0)
                        break;
                    cup = cups.Peek();
                }
                else
                {
                    cup -= bottle;
                    bottles.Pop();
                }
            }
            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedLitters}");
            }
            else 
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedLitters}");
            }
        }
    }
}
