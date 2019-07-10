﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get => firstTeam.AsReadOnly();
        }
        public IReadOnlyList<Person> ReserveTeam
        {
            get => reserveTeam.AsReadOnly();
        }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                firstTeam.Add(player);
            }
            else
            {
                reserveTeam.Add(player);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"First team has {FirstTeam.Count} players.");
            sb.AppendLine($"Reserve team has {ReserveTeam.Count} players.");

            return sb.ToString();
        }
    }
}