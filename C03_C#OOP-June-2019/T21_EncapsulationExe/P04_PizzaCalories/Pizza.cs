using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length<1 || value.Length>15)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPizzaNameLength);
                }
                this.name = value;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count==10)
            {
                throw new ArgumentException(ExceptionMessages.InvalidToppingsCount);
            }
            toppings.Add(topping);
        }

        public override string ToString()
        {
            double sumOfPizzaCalories = 0;

            foreach (var topping in toppings)
            {
                sumOfPizzaCalories += topping.CalculateTopping();
            }

            sumOfPizzaCalories += dough.CalculateDough();

            return $"{Name} - {sumOfPizzaCalories:f2} Calories.";
        }
    }
}
