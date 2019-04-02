using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[4];
            int length = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, Stats>> dragons = new Dictionary<string, Dictionary<string, Stats>>();
            for (int i = 0; i < length; i++)
            {
                input = Console.ReadLine()
                .Split();
                string color = input[0];
                string name = input[1];
                int damage = 45;int health = 250;int armor = 10;
                if (input[2] != "null")
                    damage = int.Parse(input[2]);
                if (input[3] != "null")
                    health = int.Parse(input[3]);
                if (input[4] != "null")
                    armor = int.Parse(input[4]);

                Stats stats = new Stats();
                stats.Armor = armor;
                stats.Damage = damage;
                stats.Health = health;

                if (!dragons.ContainsKey(color))
                {
                    dragons.Add(color, new Dictionary<string, Stats>());
                    dragons[color].Add(name, stats);
                }
                else
                {
                    if (dragons[color].ContainsKey(name))
                        dragons[color][name] = stats;
                    else
                        dragons[color].Add(name, stats);
                }
            }

            foreach (var color in dragons)
            {
                double aveDmg = 0, aveHp = 0, aveArm = 0;
                foreach (var stat in color.Value)
                {
                    aveDmg += stat.Value.Damage;
                    aveHp += stat.Value.Health;
                    aveArm += stat.Value.Armor;
                }
                aveDmg /= color.Value.Count;
                aveHp /= color.Value.Count;
                aveArm /= color.Value.Count;

                Console.WriteLine($"{color.Key}::({aveDmg:f2}/{aveHp:f2}/{aveArm:f2})");

                var sorted = color.Value.OrderBy(x => x.Key);
                foreach (var dragon in sorted)
                {
                    
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Damage}, health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
                }
            }
        }
    }

    class Stats
    {
        public int Damage;
        public int Health;
        public int Armor;
    }
}
