using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine,ITank
    {
        private const int initialHealth = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, initialHealth, attackPoints, defensePoints)
        {
            ToggleDefenseMode();
        }


        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            var defensiveMode = DefenseMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Defense: {defensiveMode}";
        }
    }
}
