using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
            DefaultFuelConsumption = 1.25;
            FuelConsumption = DefaultFuelConsumption;
        }

        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }


        public virtual void Drive(double kilometres)
        {
            double fuelNeeded = kilometres * FuelConsumption;
            if (fuelNeeded <= Fuel)
            {
                Fuel -= fuelNeeded;
            }
        }
    }
}
