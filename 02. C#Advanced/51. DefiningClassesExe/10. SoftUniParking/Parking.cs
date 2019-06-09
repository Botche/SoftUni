using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count { get => cars.Count; }
        public int Capacity { private get; set; }

        public Parking(int capacity)
        {
            cars = new List<Car>();
            Capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return ("Car with that registration number, already exists!");
            }
            else if (cars.Count >= Capacity)
            {
                return ("Parking is full!");
            }
            else
            {
                cars.Add(car);
                return ($"Successfully added new car {car.Make} {car.RegistrationNumber}");
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return ("Car with that registration number, doesn't exist!");
            }
            else
            {
                int index = cars.FindIndex(c => c.RegistrationNumber == registrationNumber);

                cars.RemoveAt(index);

                return ($"Successfully removed {registrationNumber}");
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.Where(c => c.RegistrationNumber == registrationNumber).First();

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                if (cars.Any(c => c.RegistrationNumber == registrationNumber))
                {
                    int index = cars.FindIndex(c => c.RegistrationNumber == registrationNumber);

                    cars.RemoveAt(index);

                    Console.WriteLine($"Successfully removed {registrationNumber}");
                }
            }
        }
    }
}
