using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int initialCubic = 125;
        private const int minimumHorsePower = 50;
        private const int maximumHorsePower = 69;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, initialCubic)
        {
            HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < minimumHorsePower || value > maximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
                }
                horsePower = value;
            }
        }
    }
}
