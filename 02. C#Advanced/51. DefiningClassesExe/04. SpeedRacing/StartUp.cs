using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                Car car = new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumption = fuelConsumption
                };
                cars.Add(car);
            }

            string[] inputAfterForLoop = new string[3];
            while ((inputAfterForLoop = Console.ReadLine()
                .Split())[0] != "End")
            {
                string model = inputAfterForLoop[1];
                double amountOfKms = double.Parse(inputAfterForLoop[2]);
                Car movingCar = cars.Where(x => x.Model == model).First();
                if (movingCar.FuelAmount >= movingCar.FuelConsumption * amountOfKms)
                {
                    movingCar.FuelAmount -= movingCar.FuelConsumption * amountOfKms;
                    movingCar.TravelledDistance += amountOfKms;
                }
                else
                    Console.WriteLine("Insufficient fuel for the drive");
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
