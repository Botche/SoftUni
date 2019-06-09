using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine()
        {
            Model = "n/a";
            Power = 0;
            Displacement = 0;
            Efficiency = "n/a";
        }
    }
}
