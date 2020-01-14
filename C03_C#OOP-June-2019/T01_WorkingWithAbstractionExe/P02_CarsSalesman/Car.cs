using System;
using System.Collections.Generic;
using System.Text;

namespace _02._CarsSalesman
{
    class Car
    {
        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public int Weight { get; private set; }
        public string Color { get; private set; }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = -1;
            Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            :this(model,engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");
            sb.AppendLine(Engine.ToString());
            sb.AppendLine($"  Weight: {(Weight == -1 ? "n/a" : Weight.ToString())}");
            sb.AppendLine($"  Color: {Color}");

            return sb.ToString();
        }
    }
}
