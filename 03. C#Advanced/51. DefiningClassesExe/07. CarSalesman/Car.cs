using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Car
    {
        private string model;
        private Engine engine;
        private double weigth;
        private string color;

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public double Weigth { get; set; }
        public string Color { get; set; }

        public Car()
        {
            Model = "n/a";
            Engine = new Engine();
            Weigth = 0;
            Color = "n/a";
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Model}:");

            sb.AppendLine($"  {Engine.Model}:");

            sb.AppendLine($"    Power: {Engine.Power}");

            if (Engine.Displacement == 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {Engine.Displacement}");
            }

            sb.AppendLine($"    Efficiency: {Engine.Efficiency}");

            if (Weigth == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {Weigth}");
            }

            sb.AppendLine($"  Color: {Color}");

            return sb.ToString();
        }
    }
}
