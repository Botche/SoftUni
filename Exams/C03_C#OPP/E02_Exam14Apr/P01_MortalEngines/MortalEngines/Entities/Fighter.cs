    using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine,IFighter
    {
        private const double initialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, initialHealthPoints, attackPoints, defensePoints)
        {
            ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else
            {
                AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }
        public override string ToString()
        {
            var aggresiveMode = AggressiveMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggresiveMode}";
        }
    }
}
