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

        public BaseMachine(string name, double healthPoints, double attackPoints, double defensePoints)
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Machine name cannot be null or empty.");
                }
                name = value;
            }
        }

        public IPilot Pilot
        {
            get => pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            var damageToDeal = Math.Abs(this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints - damageToDeal < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= damageToDeal;
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
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
