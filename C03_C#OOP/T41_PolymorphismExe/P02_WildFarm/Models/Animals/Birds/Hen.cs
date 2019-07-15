using System;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double weightOverCome = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Feed(Food food)
        {
            Weight += food.Quantity * weightOverCome;
            FoodEaten += food.Quantity;
        }
    }
}
