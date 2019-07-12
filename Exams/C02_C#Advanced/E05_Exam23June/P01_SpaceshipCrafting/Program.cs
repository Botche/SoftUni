using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liquids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> itemsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();
            int counterOfGlasses = 0;
            int counterOfAl = 0;
            int counterOfLi = 0;
            int counterOfCa = 0;

            while (liquids.Count != 0 && itemsInput.Count != 0)
            {
                int currentItem = itemsInput[0];
                int currentLiquid = liquids[0];
                int sumOfElements = currentItem + currentLiquid;
                if (sumOfElements == 25)
                {
                    counterOfGlasses++;
                    itemsInput.RemoveAt(0);
                    liquids.RemoveAt(0);
                }
                else if (sumOfElements == 50)
                {
                    counterOfAl++;
                    itemsInput.RemoveAt(0);
                    liquids.RemoveAt(0);
                }
                else if (sumOfElements == 75)
                {
                    counterOfLi++;
                    itemsInput.RemoveAt(0);
                    liquids.RemoveAt(0);
                }
                else if (sumOfElements == 100)
                {
                    counterOfCa++;
                    itemsInput.RemoveAt(0);
                    liquids.RemoveAt(0);
                }
                else
                {
                    liquids.RemoveAt(0);
                    itemsInput[0] += 3;
                }
            }
            if (counterOfAl==0 || counterOfCa==0
               ||  counterOfGlasses==0 || counterOfLi==0)
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            if (liquids.Count != 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (itemsInput.Count!=0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ",itemsInput)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine($"Aluminium: {counterOfAl}");
            Console.WriteLine($"Carbon fiber: {counterOfCa}");
            Console.WriteLine($"Glass: {counterOfGlasses}");
            Console.WriteLine($"Lithium: {counterOfLi}");
        }

    }
}
