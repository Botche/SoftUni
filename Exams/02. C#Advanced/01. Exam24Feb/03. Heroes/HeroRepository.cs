using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Heroes
{
    class HeroRepository
    {
        private List<Hero> heroes = new List<Hero>();

        public List<Hero> Heroes { get; set; }
        public int Count { get; private set; } = 0;
        public HeroRepository()
        {
            Heroes = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            Heroes.Add(hero);
            Count++;
        }

        public void Remove(string name)
        {
            Hero heroToRemove = Heroes.FirstOrDefault(x => x.Name == name);
            if (heroToRemove != null)
            {
                Count--;
                Heroes.Remove(heroToRemove);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            int maxStrength = Heroes.Max(s => s.Item.Strength);
            Hero hero = Heroes.Find(s => s.Item.Strength == maxStrength);

            return hero;
        }
        public Hero GetHeroWithHighestAbility()
        {
            int maxAbility = Heroes.Max(s => s.Item.Ability);
            Hero hero = Heroes.Find(s => s.Item.Ability == maxAbility);

            return hero;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            int maxIntelligence = Heroes.Max(s => s.Item.Intelligence);
            Hero hero = Heroes.Find(s => s.Item.Intelligence == maxIntelligence);

            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Hero hero in Heroes)
            {
                sb.AppendLine($"Hero: {hero.Name} - {hero.Level}lvl");
                sb.AppendLine($"Item:");

                sb.AppendLine($"  * Strength: {hero.Item.Strength}");

                sb.AppendLine($"  * Ability: {hero.Item.Ability}");

                sb.AppendLine($"  * Intelligence: {hero.Item.Intelligence}");

            }

            return sb.ToString();
        }
    }
}
