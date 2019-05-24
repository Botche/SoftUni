using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine()
                .Split("/");
            List<Truck> Trucks = new List<Truck>();
            List<Car> Cars = new List<Car>();
            while (data[0] != "end")
            {
                string type = data[0];
                string brand = data[1];
                string model = data[2];
                int horsePowerWeight = int.Parse(data[3]);

                if (type == "Car")
                {
                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePowerWeight
                    };
                    Cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = horsePowerWeight
                    };
                    Trucks.Add(truck);
                }
                data = Console.ReadLine()
                                .Split("/");
            }
            List<Car> SortedList = Cars.OrderBy(a => a.Brand).ToList();
            if (Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in SortedList)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            List<Truck> SortedTrucks = Trucks.OrderBy(x => x.Brand).ToList();
            if (Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in SortedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }

        class Truck
        {
            public string Brand;
            public string Model;
            public int Weight;
        }

        class Car
        {
            public string Brand;
            public string Model;
            public int HorsePower;
        }
    }
}
