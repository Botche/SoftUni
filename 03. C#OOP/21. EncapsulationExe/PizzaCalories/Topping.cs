using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private int weight;
        private double toppingModifier;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (value.ToLower() == "meat")
                {
                    toppingModifier = 1.2;
                }
                else if (value.ToLower() == "veggies")
                {
                    toppingModifier = 0.8;
                }
                else if (value.ToLower() == "cheese")
                {
                    toppingModifier = 1.1;
                }
                else if (value.ToLower() == "sauce")
                {
                    toppingModifier = 0.9;
                }
                else
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidToppingType, value));
                }
                this.type = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value<1 || value>50)
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidToppingWeight, Type));
                }
                this.weight = value;
            }
        }
        public double CalculateTopping()
        {
            double sumOfToppings = 0;

            sumOfToppings = weight * toppingModifier * 2;

            return sumOfToppings;
        }
    }
}
