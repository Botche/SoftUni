using System;
using System.Collections.Generic;

namespace _08._TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int count = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    if (cars.Count < numberOfCars)
                    {
                        numberOfCars = cars.Count;
                    }
                    for (int i = 0; i < numberOfCars; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                }
                else
                {
                    string car = command;
                    cars.Enqueue(car);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
