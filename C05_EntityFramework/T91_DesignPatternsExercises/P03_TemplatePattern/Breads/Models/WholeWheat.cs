using System;

namespace P03_TemplatePattern.Breads.Models
{
    class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering Ingredients for WholeWheat Bread.");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the WholeWheat Bread (20 minutes)");
        }
    }
}
