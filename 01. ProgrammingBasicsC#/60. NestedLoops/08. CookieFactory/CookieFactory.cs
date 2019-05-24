using System;

namespace cookieFactory
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string product = string.Empty;
            int counter = 0,counter1=0;
            for(counter=0;counter<n;)
            {
                product = Console.ReadLine();
                while (product!="Bake!")
                {
                    if (product == "eggs")
                        counter1++;
                    else if(product == "sugar")
                        counter1++;
                    else if (product == "flour")
                        counter1++;
                    product = Console.ReadLine();
                }
                if (counter1 != 3)
                {
                    Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    continue;
                }
                else
                {
                    counter++;
                    Console.WriteLine($"Baking batch number {counter}...");
                    counter1 = 0;
                }
            }
        }
    }
}
