using System;
using System.Collections.Generic;
using System.Text;

namespace _03._FightingArena
{
    class Gladiator
    {
        private string name;
        private Stat stat;
        private Weapon weapon;

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        public int GetTotalPower()
        {
            int sumOfWeapon = GetWeaponPower();
            int sumOfStat = GetStatPower();

            return sumOfStat + sumOfWeapon;
        }


        public int GetWeaponPower()
        {
            int sum = Weapon.Sharpness + Weapon.Size + Weapon.Solidity;

            return sum;
        }
        public int GetStatPower()
        {
            int sum = Stat.Agility + Stat.Flexibility + Stat.Intelligence + Stat.Skills + Stat.Strength;

            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} - {GetTotalPower()}");
            sb.AppendLine($"  Weapon Power: {GetWeaponPower()}");
            sb.AppendLine($"  Stat Power: {GetStatPower()}");

            return sb.ToString();
        }
    }
}
