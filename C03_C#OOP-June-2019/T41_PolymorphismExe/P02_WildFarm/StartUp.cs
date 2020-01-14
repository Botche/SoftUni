using System;
using System.Collections.Generic;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal = InitializeAnimal(tokens);
                animals.Add(animal);

                animal.MakeSound();

                tokens = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                FeedAnimals(tokens, animal);
            }

            PrintAnimals(animals);
        }

        private static void PrintAnimals(List<Animal> animals)
        {
            foreach (var @animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void FeedAnimals(string[] tokens, Animal animal)
        {
            var foodType = tokens[0];
            var quantity = int.Parse(tokens[1]);

            Food food = InitializeFood(foodType, quantity);

            animal.Feed(food);
        }

        private static Food InitializeFood(string foodType, int quantity)
        {
            Food food = null;

            if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }

            return food;
        }

        private static Animal InitializeAnimal(string[] tokens)
        {
            var animalType = tokens[0];
            var name = tokens[1];
            var weight = double.Parse(tokens[2]);
            Animal animal = null;

            if (animalType == "Hen")
            {
                double wingSize = double.Parse(tokens[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else if (animalType == "Owl")
            {
                double wingSize = double.Parse(tokens[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == "Cat")
            {
                var livingRegion = tokens[3];
                var breed = tokens[4];

                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (animalType == "Tiger")
            {
                var livingRegion = tokens[3];
                var breed = tokens[4];

                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else if (animalType == "Dog")
            {
                var livingRegion = tokens[3];

                animal = new Dog(name, weight, livingRegion);
            }
            else if (animalType == "Mouse")
            {
                var livingRegion = tokens[3];

                animal = new Mouse(name, weight, livingRegion);
            }

            return animal;
        }
    }
}
