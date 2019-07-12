using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine()
                    .Split();
                string[] doughInput = Console.ReadLine()
                    .Split();

                string flourType = doughInput[1];
                string bakingTechnique = doughInput[2];
                int weight = int.Parse(doughInput[3]);

                var dough = new Dough(flourType, bakingTechnique, weight);

                var pizza = new Pizza(pizzaInput[1], dough);

                string command = string.Empty;
                while ((command=Console.ReadLine())!="END")
                {
                    string[] toppingTokens = command.Split();

                    string toppingName = toppingTokens[1];
                    int toppingWeight = int.Parse(toppingTokens[2]);

                    var topping = new Topping(toppingName, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
