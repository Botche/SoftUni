using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double initialHP = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, initialHP, attackPoints, defensePoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                AttackPoints -= 50;
                DefensePoints += 25;

                AggressiveMode = false;
            }
            else
            {
                AttackPoints += 50;
                DefensePoints -= 25;

                AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            var aggresiveModeInfo = AggressiveMode ? "ON" : "OFF";

            return base.ToString()+Environment.NewLine+$" *Aggressive: {aggresiveModeInfo}";
        }
    }
}
