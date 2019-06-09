using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car()
        {
            Engine = new Engine();
            Cargo = new Cargo();
            Tires = new Tire[4];
        }
        public Car(string model)
        {
            Model = model;
            Engine = new Engine();
            Cargo = new Cargo();
            Tires = new Tire[4];
        }
        public Car(string model,
            int engineSpeed,
            int enginePower,
            int cargoWeight,
            string cargoType,
            Tire[] tires)
        {
            Model = model;
            Engine.EnginePower = enginePower;
            Engine.EngineSpeed = engineSpeed;
            Cargo.CargoType = cargoType;
            Cargo.CargoWeigth = cargoWeight;
            Tires = tires;
        }

    }
}
