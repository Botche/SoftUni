using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot: IPilot
    {
        private string name;
        private readonly List<IMachine> machines;

        public Pilot(string name)
        {
            Name = name;
            machines = new List<IMachine>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Pilot name cannot be null or empty string.");
                }
                name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {machines.Count} machines");

            foreach (var machine in machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
