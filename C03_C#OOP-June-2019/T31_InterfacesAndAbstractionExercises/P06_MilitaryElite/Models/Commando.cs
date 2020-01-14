using MilitaryElite.Interfaces;
using P06_MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier,ICommando
    {
        private List<Mission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            :base(id,firstName,lastName,salary,corps)
        {
            missions = new List<Mission>();
        }

        public IReadOnlyCollection<Mission> Missions { get => missions; }

        public void AddMission(Mission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
