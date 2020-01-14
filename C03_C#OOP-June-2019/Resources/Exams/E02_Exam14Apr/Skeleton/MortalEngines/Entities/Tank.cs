using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double initialHP = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, initialHP, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                AttackPoints += 40;
                DefensePoints -= 30;

                DefenseMode = false;
            }
            else
            {
                AttackPoints -= 40;
                DefensePoints += 30;

                DefenseMode = true;
            }
        }

        public override string ToString()
        {
            var defensiveModeInfo = DefenseMode ? "ON" : "OFF";

            return base.ToString()+Environment.NewLine+ $" *Defense: {defensiveModeInfo}";
        }
    }
}
