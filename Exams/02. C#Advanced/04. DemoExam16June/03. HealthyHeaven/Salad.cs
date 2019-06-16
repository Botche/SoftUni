using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    class Salad
    {
        private List<Vegetable> Vegetables;
        public string Name { get; private set; }

        public Salad(string name)
        {
            Name = name;
            Vegetables = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            return Vegetables.Sum(v => v.Calories);
        }

        public int GetProductCount()
        {
            return Vegetables.Count();
        }

        public void Add(Vegetable vegetable)
        {
            Vegetables.Add(vegetable);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"* Salad {Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");
            foreach (var vegetable in Vegetables)
            {
                sb.AppendLine($"{vegetable}");
            }

            return sb.ToString().Trim();
        }
    }
}
