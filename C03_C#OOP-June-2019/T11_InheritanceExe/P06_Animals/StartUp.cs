using Animals.Cats;
using Animals.Dogs;
using Animals.Frogs;
using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            // Try without validation for gender 
            var animals = new List<string>();

            string command = null;

            while ((command = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string typeAnimal = command;

                    command = Console.ReadLine();

                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (tokens.Length!=3)
                    {
                        throw new Exception();
                    }

                    string animalName = tokens[0];
                    int animalAge = int.Parse(tokens[1]);
                    string animalGender = tokens[2];

                    Animal animal = null;
                    switch (typeAnimal)
                    {
                        case "Cat":
                            var cat = new Cat(animalName, animalAge, animalGender);
                            animal= cat;
                            break;
                        case "Kitten":
                            if (animalGender != "Female")
                            {
                                throw new Exception();
                            }
                            var kitten = new Kitten(animalName, animalAge);
                            animal = kitten;
                            break;
                        case "Tomcat":
                            if (animalGender!="Male")
                            {
                                throw new Exception();
                            }
                            var tomcat = new Tomcat(animalName, animalAge);
                            animal = tomcat;
                            break;
                        case "Dog":
                            var dog = new Dog(animalName, animalAge, animalGender);
                            animal = dog;
                            break;
                        case "Frog":
                            var frog = new Frog(animalName, animalAge, animalGender);
                            animal = frog;
                            break;
                        default:
                            throw new Exception();
                    }
                    animals.Add(animal.ToString());
                }
                catch (Exception ex)
                {
                    animals.Add("Invalid input!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
