using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ");
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (data[0] != "End")
            {
                data[0]=data[0].ToLower();
                if (data[0] == "car")
                {
                    Car car = new Car();
                    car.Type = data[0];
                    car.Model = data[1];
                    car.Color = data[2];
                    car.HorsePower = int.Parse(data[3]);
                    cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck();
                    truck.Type = data[0];
                    truck.Model = data[1];
                    truck.Color = data[2];
                    truck.HorsePower = int.Parse(data[3]);
                    trucks.Add(truck);
                }
                data = Console.ReadLine().Split();
            }
            string vehicle = Console.ReadLine();
            while (vehicle != "Close the Catalogue")
            {
                Car result = cars.Find(x => x.Model == vehicle);
                if (result == null)
                {
                    Truck resultOne = trucks.Find(x => x.Model == vehicle);
                    if (resultOne != null)
                    {
                        Console.WriteLine($"Type: Truck");
                        Console.WriteLine($"Model: {resultOne.Model}");
                        Console.WriteLine($"Color: {resultOne.Color}");
                        Console.WriteLine($"Horsepower: {resultOne.HorsePower}");
                    }
                }
                else
                {
                    Console.WriteLine($"Type: Car");
                    Console.WriteLine($"Model: {result.Model}");
                    Console.WriteLine($"Color: {result.Color}");
                    Console.WriteLine($"Horsepower: {result.HorsePower}");
                }
                vehicle = Console.ReadLine();
            }
            double sum = 0;
            foreach (var car in cars)
            {
                sum += car.HorsePower;
            }
            if (cars.Count>0)
                Console.WriteLine($"Cars have average horsepower of: {Math.Round(sum/cars.Count,2):F2}.");
            else Console.WriteLine($"Cars have average horsepower of: 0.00.");
            
            sum = 0;
            foreach (var truck in trucks)
            {
                sum += truck.HorsePower;
            }
            if (trucks.Count>0)
                Console.WriteLine($"Trucks have average horsepower of: {Math.Round(sum / trucks.Count, 2):F2}.");
            else Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            
        }

        class Car
        {
            public string Type;
            public string Model;
            public string Color;
            public int HorsePower;
        }

        class Truck
        {
            public string Type;
            public string Model;
            public string Color;
            public int HorsePower;
        }
    }
}
