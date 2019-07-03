using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._RawData
{

    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());

            FillCars(cars, lines);

            string command = Console.ReadLine();

            PrintCarsWithCargoType(command, cars);
        }

        private static void FillCars(List<Car> cars, int numberOfCarsInput)
        {
            for (int i = 0; i < numberOfCarsInput; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(parameters[5]);
                int tire1age = int.Parse(parameters[6]);

                double tire2Pressure = double.Parse(parameters[7]);
                int tire2age = int.Parse(parameters[8]);

                double tire3Pressure = double.Parse(parameters[9]);
                int tire3age = int.Parse(parameters[10]);

                double tire4Pressure = double.Parse(parameters[11]);
                int tire4age = int.Parse(parameters[12]);

                Tire[] tires = new Tire[4] { new Tire(tire1Pressure, tire1age),
                    new Tire(tire2Pressure,tire2age),
                    new Tire(tire3Pressure,tire3age),
                    new Tire(tire4Pressure,tire4age)};

                cars.Add(new Car(model, engine, cargo, tires));
            }
        }
        private static void PrintCarsWithCargoType(string command, List<Car> cars)
        {
            if (command == "fragile")
            {
                PrintTypeCargoFragile(cars);
            }
            else
            {
                PrintTypeCargoFlamable(cars);
            }
        }
        private static void PrintTypeCargoFlamable(List<Car> cars)
        {
            List<string> flamable = cars
                       .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                       .Select(x => x.Model)
                       .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, flamable));
        }

        private static void PrintTypeCargoFragile(List<Car> cars)
        {
            List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Age < 1))
                    .Select(x => x.Model)
                    .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, fragile));
        }
    }
}
