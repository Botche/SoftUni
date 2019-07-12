using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> astronauts;

        public SpaceStation(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            astronauts = new List<Astronaut>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => astronauts.Count;

        public void Add(Astronaut astronaut)
        {
            if (astronauts.Count != Capacity)
            {
                astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            bool isRemoved = false;

            Astronaut astronautToRemove = astronauts.FirstOrDefault(a => a.Name == name);

            if (astronautToRemove != null)
            {
                astronauts.Remove(astronautToRemove);
                isRemoved = true;
            }
            return isRemoved;
        }

        public Astronaut GetOldestAstronaut()
        {
            int oldestAge = astronauts.Max(a => a.Age);

            Astronaut astronaut = astronauts.FirstOrDefault(a => a.Age == oldestAge);

            return astronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronaut = astronauts.Find(a => a.Name == name);

            return astronaut;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {Name}:");
            foreach (var astronaut in astronauts)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
