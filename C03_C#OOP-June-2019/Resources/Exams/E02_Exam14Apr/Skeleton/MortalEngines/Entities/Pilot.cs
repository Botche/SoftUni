using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private readonly IList<IMachine> machines;

        public Pilot(string name)
        {
            Name = name;
            machines=new List<IMachine>();
        }

        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfStringIsEmptyOrNull(value, ExceptionMessages.InvalidPilotName);
                name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            Validator.ThrowIfObjectIsNull(machine, ExceptionMessages.NullMachineTriedToAddToPilot);

            this.machines.Add(machine);
           // machine.Pilot = this;
        }
        // Try without machine.ToString()
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
