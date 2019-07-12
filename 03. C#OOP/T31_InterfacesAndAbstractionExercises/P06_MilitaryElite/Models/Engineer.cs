using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : IEngineer
    {
        private string corps;
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Corps = corps;
            Repairs = new List<Repair>();
        }

        public string Id { get; } 
        public string FirstName { get; } 
        public string LastName { get; }
        public decimal Salary { get; }
        public string Corps
        {
            get => corps;
            private set
            {
                ValidateCorps(value);
                corps = value;
            }
        }
        public List<Repair> Repairs { get; }

        public void AddRepair(Repair repair)
        {
            Repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");

            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

        private static void ValidateCorps(string value)
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new Exception();
            }
        }
    }
}
