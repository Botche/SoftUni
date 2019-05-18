using System;
using System.Collections.Generic;

namespace _06._AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> carsForService = new Queue<string>(input);
            Stack<string> servedCars = new Stack<string>();

            string[] command = Console.ReadLine().Split("-");
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Service":
                        if (carsForService.Count != 0)
                        {
                            string car = carsForService.Peek();
                            Console.WriteLine($"Vehicle {car} got served.");
                            servedCars.Push(car);
                            carsForService.Dequeue();
                        }
                        break;
                    case "CarInfo":
                        string carForInfo = command[1];
                        if (carsForService.Contains(carForInfo))
                            Console.WriteLine("Still waiting for service.");
                        else
                            Console.WriteLine("Served.");
                        break;
                    case "History":
                        Console.WriteLine(string.Join(", ", servedCars));
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine().Split("-");
            }
            if (carsForService.Count != 0)
                Console.WriteLine($"Vehicles for service: {string.Join(", ", carsForService)}");
            if (servedCars.Count != 0)
                Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
        }
    }
}
