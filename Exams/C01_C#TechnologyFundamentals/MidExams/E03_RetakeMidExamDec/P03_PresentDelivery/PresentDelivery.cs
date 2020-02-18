using System;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();
            
            bool[] bools = new bool[houses.Length];
            for (int i = 0; i < bools.Length; i++)
            {
                bools[i] = false;
            }

            int houseIndex = 0;
            string[] jump = Console.ReadLine().Split();
            while (jump[0] != "Merry")
            {
                int length = int.Parse(jump[1]);

                while (houseIndex + length > houses.Length - 1)
                {
                    length = length - houses.Length;
                }
                houseIndex += length;

                if (houses[houseIndex] == 0)
                {
                    Console.WriteLine($"House {houseIndex} will have a Merry Christmas.");
                }
                else
                {
                    houses[houseIndex] -= 2;
                    if (houses[houseIndex] == 0)
                        bools[houseIndex] = true;
                }
                jump = Console.ReadLine().Split();
            }

            Console.WriteLine($"Santa's last position was {houseIndex}.");

            bool misson = true;
            int count = 0;
            for (int i = 0; i < houses.Length; i++)
            {
                if (bools[i] == false)
                {
                    misson = false;
                    count++;
                }
            }

            if (misson == false)
            {
                Console.WriteLine($"Santa has failed {count} houses.");
            }
            else
                Console.WriteLine("Mission was successful.");
        }
    }
}
