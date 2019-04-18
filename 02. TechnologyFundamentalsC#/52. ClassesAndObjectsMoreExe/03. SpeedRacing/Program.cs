using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < amountOfCars; i++)
            {
                string[] input = Console.ReadLine().Split();

                Car car = new Car();
                car.Model = input[0];
                car.FuelAmount = double.Parse(input[1]);
                car.FuelConsumptionForOneKM = double.Parse(input[2]);
                car.TraveledDistance = 0;
                cars.Add(car);
            }
            string[] command = Console.ReadLine().Split();
            while (command[0]!="End")
            {
                string carModel = command[1];
                double KMs = double.Parse(command[2]);
                var carForDrive = cars.Find(i => i.Model == carModel);
                Car.TravelDistance(carForDrive,KMs);
                command = Console.ReadLine().Split();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }

    class Car
    {
        public string Model;
        public double FuelAmount;
        public double FuelConsumptionForOneKM;
        public double TraveledDistance;

        public static void TravelDistance(Car carForDrive, double kMs)
        {
            double usedFuel = carForDrive.FuelConsumptionForOneKM * kMs;
            if (usedFuel <= carForDrive.FuelAmount)
            {
                carForDrive.FuelAmount -= usedFuel;
                carForDrive.TraveledDistance += kMs;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
