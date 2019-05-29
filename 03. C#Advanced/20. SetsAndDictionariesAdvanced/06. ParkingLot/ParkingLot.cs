using System;
using System.Collections.Generic;

namespace _06._ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0]!="END")
            {
                string command = input[0];
                string carNumber = input[1];

                if (command=="IN")
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    carNumbers.Remove(carNumber);
                }

                input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (carNumbers.Count==0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            foreach (var carNumber in carNumbers)
            {
                Console.WriteLine(carNumber);
            }
        }
    }
}
