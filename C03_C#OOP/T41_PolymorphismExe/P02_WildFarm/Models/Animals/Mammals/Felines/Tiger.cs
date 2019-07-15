using System;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double weightOverCome = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                Weight += food.Quantity * weightOverCome;
                FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
