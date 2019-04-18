using System;
namespace fruitOrVegetable
{
    class Program
    {
        static void Main()
        {
            string fruit = Console.ReadLine();
            if (fruit == "kiwi" || fruit == "banana" || fruit == "apple" || fruit == "cherry" || fruit == "grapes" || fruit == "lemon")
                Console.WriteLine("fruit");
            else if(fruit == "tomato" || fruit == "cucumber" || fruit == "pepper" || fruit == "carrot")
                Console.WriteLine("vegetable");
            else 
                Console.WriteLine("unknown");
        }
    }
}
