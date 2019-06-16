using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthyHeaven
{
    class Restaurant
    {
        private List<Salad> salads;
        public string Name { get; private set; }

        public Restaurant(string name)
        {
            Name = name;
            salads = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            salads.Add(salad);
        }

        public bool Buy(string name)
        {
            bool isThere = false;

            Salad saladToRemove = salads.Find(s => s.Name == name);

            if (saladToRemove!=null)
            {
                salads.Remove(saladToRemove);
                isThere = true;
            }

            return isThere;
        }

        public Salad GetHealthiestSalad()
        {
            int minCalo = salads.Min(s=>s.GetTotalCalories());

            Salad salad = salads.Find(s=>s.GetTotalCalories() == minCalo);

            return salad;
        }

        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} have {salads.Count} salads:");
            foreach (var salad in salads)
            {
                sb.AppendLine($"{salad}");
            }

            return sb.ToString().Trim();
        }
    }
}
