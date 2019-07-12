using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            CollectEngines(enginesCount, engines);

            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            CollectCars(carsCount, cars, engines);

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");

                Console.WriteLine($"  {car.Engine.Model}:");

                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement==0)
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }

                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");

                if (car.Weigth == 0)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weigth}");
                }

                Console.WriteLine($"  Color: {car.Color}");
            }
        }

        private static void CollectCars(int carsCount, List<Car> cars, List<Engine> engines)
        {
            for (int i = 0; i < carsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string engineModel = input[1];
                double weight = 0;
                string color = "n/a";

                if (input.Length == 4)
                {
                    if (char.IsDigit(input[2][0]))
                    {
                        weight = double.Parse(input[2]);
                        color = input[3];
                    }
                    else
                    {
                        color = input[2];
                        weight = double.Parse(input[3]);
                    }
                }
                else if (input.Length==3)
                {
                    if (char.IsDigit(input[2][0]))
                    {
                        weight = int.Parse(input[2]);
                    }
                    else
                    {
                        color = input[2];
                    }
                }


                Engine rightModelEngineForThisCar = engines.First(x => x.Model == engineModel);
                Car car = new Car()
                {
                    Model = model,
                    Engine = rightModelEngineForThisCar,
                    Weigth = weight,
                    Color = color
                };

                cars.Add(car);
            }
        }

        private static void CollectEngines(int enginesCount, List<Engine> engines)
        {
            for (int i = 0; i < enginesCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int power = int.Parse(input[1]);
                int displacement = 0;
                string efficiency = "n/a";

                if (input.Length == 4)
                {
                    displacement = int.Parse(input[2]);
                    efficiency = input[3];
                }
                else if (input.Length == 3)
                {
                    if (char.IsDigit(input[2][0]))
                    {
                        displacement = int.Parse(input[2]);
                    }
                    else
                    {
                        efficiency = input[2];
                    }
                }

                Engine engine = new Engine()
                {
                    Model = model,
                    Power = power,
                    Displacement = displacement,
                    Efficiency = efficiency
                };

                engines.Add(engine);
            }
        }
    }
}
