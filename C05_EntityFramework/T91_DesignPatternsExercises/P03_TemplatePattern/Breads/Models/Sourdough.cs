using System;

namespace P03_TemplatePattern.Breads.Models
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the Sourdough Bread (20 minutes)");
        }
    }
}
