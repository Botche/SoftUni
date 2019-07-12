using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Tire
    {
        private double pressure;
        private int age;

        public double Pressure { get; set; }
        public int Age { get; set; }

        public Tire()
        {

        }

        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }
}
