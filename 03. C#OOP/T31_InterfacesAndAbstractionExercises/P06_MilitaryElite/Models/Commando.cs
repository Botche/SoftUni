using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : ICommando
    {
        private string corps;
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Corps = corps;
            Missions = new List<Mission>();
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

        private static void ValidateCorps(string value)
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new Exception();
            }
        }

        public List<Mission> Missions { get; }

        public void AddMission(Mission mission)
        {
            Missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");

            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
