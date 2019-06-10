using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._FightingArena
{
    class Arena
    {
        private List<Gladiator> gladiators;
        private string name;

        public string Name { get; set; }
        public int Count { get; private set; } = 0;

        public Arena(string name)
        {
            Name = name;
            gladiators = new List<Gladiator>();
        }
        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
            Count++;
        }
        public Gladiator Remove(string name)
        {
            Gladiator gladiator = gladiators.Find(x => x.Name == name);

            if (gladiators.Contains(gladiator))
            {
                gladiators.Remove(gladiator);
                Count--;
            }

            return gladiator;
        }
        public Gladiator GetGladitorWithHighestStatPower()
        {
            int maxStatPower = gladiators.Max(x => x.GetStatPower());

            Gladiator gladiator = gladiators.Find(g => g.GetStatPower() == maxStatPower);

            return gladiator;
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int maxWeaponPower = gladiators.Max(x => x.GetWeaponPower());

            Gladiator gladiator = gladiators.Find(g => g.GetWeaponPower() == maxWeaponPower);

            return gladiator;
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int maxTotalPower = gladiators.Max(x => x.GetTotalPower());

            Gladiator gladiator = gladiators.Find(g => g.GetTotalPower() == maxTotalPower);

            return gladiator;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} - {Count} gladiators are participating.");

            return sb.ToString();
        }
    }
}
