using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
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
                car.Engine = new Engine();
                car.Cargo = new Cargo();

                car.Model = input[0];
                car.Engine.EngineSpeed = int.Parse(input[1]);
                car.Engine.EnginePower = int.Parse(input[2]);
                car.Cargo.CargoWeight = int.Parse(input[3]);
                car.Cargo.CargoType = input[4];

                cars.Add(car);
            }

            string cargoType = Console.ReadLine();
            PringCarsWithCargo(cargoType, cars);
        }

        private static void PringCarsWithCargo(string cargoType, List<Car> cars)
        {
            var sorted = cars.FindAll(x => x.Cargo.CargoType == cargoType).ToList();
            if (cargoType == "fragile")
            {
                foreach (var car in sorted)
                {
                    if (car.Cargo.CargoWeight < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else
            {
                foreach (var car in sorted)
                {
                    if (car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }

    class Car
    {
        public string Model;
        public Engine Engine;
        public Cargo Cargo;
    }

    class Engine
    {
        public int EngineSpeed;
        public int EnginePower;
    }

    class Cargo
    {
        public int CargoWeight;
        public string CargoType;
    }
}
