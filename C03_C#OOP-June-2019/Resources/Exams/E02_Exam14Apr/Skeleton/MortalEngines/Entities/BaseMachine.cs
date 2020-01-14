using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            Name = name;
            HealthPoints = healthPoints;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            Targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowIfStringIsEmptyOrNull(value, ExceptionMessages.InvalidMachineName);
                name = value;
            }
        }


        public IPilot Pilot
        {
            get => pilot;
            set
            {
                Validator.ThrowIfObjectIsNull(value, ExceptionMessages.NullPilot);
                pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }
        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            Validator.ThrowIfObjectIsNull(target, ExceptionMessages.NullTarget);

            var dmgToDeal = Math.Abs(this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints - dmgToDeal < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= dmgToDeal;
            }

            Targets.Add(target.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}")
             .AppendLine($" *Type: {this.GetType().Name}")
             .AppendLine($" *Health: {this.HealthPoints:f2}")
             .AppendLine($" *Attack: {this.AttackPoints:f2}")
             .AppendLine($" *Defense: {this.DefensePoints:f2}");

            if (this.Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
