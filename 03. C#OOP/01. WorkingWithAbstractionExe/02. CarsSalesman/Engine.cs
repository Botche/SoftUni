using System;
using System.Collections.Generic;
using System.Text;

namespace _02._CarsSalesman
{
    class Engine
    {
        public string Model { get; private set; }
        public int Power { get; private set; }
        public int Displacement { get; private set; }
        public string Efficiency { get; private set; }

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = -1;
            Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            :this(model,power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"  {Model}:");
            sb.AppendLine($"    Power: {Power}");
            sb.AppendLine($"    Displacement: {(Displacement == -1 ? "n/a" : Displacement.ToString())}");
            sb.AppendLine($"    Efficiency: {Efficiency}");

            return sb.ToString();
        }
    }
}
