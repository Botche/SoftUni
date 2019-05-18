using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Stack<int> sequence = new Stack<int>(input);
            int capacityOfRack = int.Parse(Console.ReadLine());

            int sumOfClothes= 0;
            int numberOfRacks = 0;
            while (sequence.Count != 0)
            {
                int clothes = sequence.Peek();
                if (sumOfClothes+clothes < capacityOfRack)
                    sumOfClothes += clothes;
                else if(sumOfClothes+clothes==capacityOfRack)
                {
                    numberOfRacks++;
                    sumOfClothes = 0;
                }
                else
                {
                    numberOfRacks++;
                    sumOfClothes = clothes;
                }
                sequence.Pop();
            }
            if (sumOfClothes != 0)
                numberOfRacks++;
            Console.WriteLine(numberOfRacks);
        }
    }
}
