using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;

namespace P06_MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps
        {
            get => corps;
            private set
            {
                ValidateCorps(value);
                corps = value;
            }
        }
        private static void ValidateCorps(string value)
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corps}";
        }
    }
}
