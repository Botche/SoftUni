using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;
        private double flourModifier;
        private double bakingModifier;

        public Dough(string flourType, string backingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = backingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (value.ToLower() == "white")
                {
                    flourModifier = 1.5;
                }
                else if (value.ToLower() == "wholegrain")
                {
                    flourModifier = 1.0;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (value.ToLower() == "crispy")
                {
                    bakingModifier=0.9;
                }
                else if (value.ToLower() == "chewy")
                {
                    bakingModifier = 1.1;
                }
                else if (value.ToLower() == "homemade")
                {
                    bakingModifier = 1.0;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }
                bakingTechnique = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value<1 || value>200)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughWeight);
                }
                this.weight = value;
            }
        }

        public double CalculateDough()
        {
            double sumOfDough = 0;

            sumOfDough = 2 * Weight * flourModifier * bakingModifier;

            return sumOfDough;
        }
    }
}
