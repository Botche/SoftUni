using System;

namespace ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int budget = 0, christmasSpirit = 0;
            int ornamentSet = 2, treeSkirt = 5, treeGarlands = 3, treeLights = 15;

            for (int day = 1; day <= days; day++)
            {
                if (day % 11 == 0)
                {
                    quantity += 2;
                }
                if (day % 2 == 0)
                {
                    budget += ornamentSet * quantity;
                    christmasSpirit += 5;
                }
                if (day % 3 == 0)
                {
                    budget += treeSkirt * quantity + treeGarlands * quantity;
                    christmasSpirit += 13;
                }
                if (day % 5 == 0)
                {
                    budget += treeLights * quantity;
                    christmasSpirit += 17;
                    if (day % 3 == 0)
                        christmasSpirit += 30;
                }
                if (day % 10 == 0)
                {
                    christmasSpirit -= 20;
                    budget += treeLights + treeGarlands + treeSkirt;
                }
            }
            if (days % 10 == 0)
                christmasSpirit -= 30;
            Console.WriteLine($"Total cost: {budget}");
            Console.WriteLine($"Total spirit: {christmasSpirit}");
        }
    }
}
