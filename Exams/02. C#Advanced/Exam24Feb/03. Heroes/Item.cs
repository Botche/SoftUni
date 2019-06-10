using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Heroes
{
    class Item
    {
        private int strength;
        private int ability;
        private int intelligence;

        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public Item(int strength, int ability, int intelligence)
        {
            Strength = strength;
            Ability = ability;
            Intelligence = intelligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Item:");

            sb.AppendLine($"  * Strength: {Strength}");

            sb.AppendLine($"  * Ability: {Ability}");

            sb.AppendLine($"  * Intelligence: {Intelligence}");

            return sb.ToString();
        }
    }
}
