using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeigth = int.Parse(input[3]);
                string cargoType = input[4];

                double firstTirePressure = double.Parse(input[5]);
                int firstTireYear = int.Parse(input[6]);
                Tire firstTire = new Tire(firstTireYear, firstTirePressure);

                double secondTirePressure = double.Parse(input[5]);
                int secondTireYear = int.Parse(input[6]);
                Tire secondTire = new Tire(secondTireYear, secondTirePressure);

                double thirdTirePressure = double.Parse(input[5]);
                int thirdTireYear = int.Parse(input[6]);
                Tire thirdTire = new Tire(thirdTireYear, thirdTirePressure);

                double fourthTirePressure = double.Parse(input[5]);
                int fourthTireYear = int.Parse(input[6]);
                Tire fourthTire = new Tire(fourthTireYear, fourthTirePressure);

                Tire[] tires = new Tire[]
                {
                    firstTire,
                    secondTire,
                    thirdTire,
                    fourthTire
                };

                Car car = new Car(model);

                car.Engine.EnginePower = enginePower;
                car.Engine.EngineSpeed = engineSpeed;

                car.Cargo.CargoType = cargoType;
                car.Cargo.CargoWeigth = cargoWeigth;

                car.Tires = tires;

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command=="fragile")
            {
                PrintAllFragileCars(cars);
            }
            else
            {
                PrintAllFlamableCars(cars);
            }
        }

        private static void PrintAllFlamableCars(List<Car> cars)
        {
            var sorted = cars.Where(c => c.Cargo.CargoType == "flamable")
                .Where(c=>c.Engine.EnginePower>250);

            foreach (var car in sorted)
            {
                Console.WriteLine(car.Model);
            }
        }

        private static void PrintAllFragileCars(List<Car> cars)
        {
            var sorted = cars.Where(c => c.Cargo.CargoType == "fragile");

            foreach (var car in sorted)
            {
                foreach (var tire in car.Tires)
                {
                    if (tire.Pressure<1)
                    {
                        Console.WriteLine(car.Model);
                        break;
                    }
                }
            }
        }
    }
}
