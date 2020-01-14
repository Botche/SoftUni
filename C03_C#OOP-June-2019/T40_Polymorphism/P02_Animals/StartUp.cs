using Animals.Models;
using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal cat = new Cat("Pesho", "Whiskas");
            Animal dog = new Dog("Gosho", "Meat");

            PrintExplainSelf(cat);
            PrintExplainSelf(dog);
        }

        private static void PrintExplainSelf(Animal animal)
        {
            Console.WriteLine(animal.ExplainSelf());
        }
    }
}
