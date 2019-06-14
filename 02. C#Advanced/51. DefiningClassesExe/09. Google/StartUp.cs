using System;
using System.Collections.Generic;
using System.Globalization;

namespace _09._Google
{
    class StartUp

    {
        static void Main(string[] args)
        {
            string[] input = new string[5];
            List<Person> people = new List<Person>();

            while ((input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries))[0] != "End")
            {
                string name = input[0];
                if (!people.Exists(x=>x.Name==name))
                {
                    Person person = new Person(name);
                    people.Add(person);
                }
                string format = "dd/MM/yyyy";
                CultureInfo provider = CultureInfo.InvariantCulture;
                switch (input[1])
                {
                    case "company":
                        Person personToAddCompany = people.Find(p => p.Name == name);
                        
                        personToAddCompany.Company.Name = input[2];
                        personToAddCompany.Company.Department = input[3];
                        personToAddCompany.Company.Salary = double.Parse(input[4]);
                        break;
                    case "car":
                        Person personToAddCar = people.Find(p => p.Name == name);

                        personToAddCar.Car.Model = input[2];
                        personToAddCar.Car.Speed = int.Parse(input[3]);
                        break;
                    case "pokemon":
                        Person personToAddPokemon= people.Find(p => p.Name == name);
                        Pokemon pokemon = new Pokemon(input[2], input[3]);
                        personToAddPokemon.Pokemon.Add(pokemon);
                        break;
                    case "parents":
                        Person personToAddParents = people.Find(p => p.Name == name);
                        Parents parents = new Parents(input[2], DateTime.ParseExact(input[3], format, provider));
                        personToAddParents.Parents.Add(parents);
                        break;
                    case "children":
                        Person personToAddChildren = people.Find(p => p.Name == name);
                        Children children=new Children(input[2], DateTime.ParseExact(input[3], format,provider));
                        personToAddChildren.Children.Add(children);
                        break;
                    default:
                        break;
                }
            }
            string personToFind = Console.ReadLine();

            Person personFound = people.Find(p => p.Name == personToFind);

            Console.WriteLine(personToFind);
            Console.WriteLine("Company:");
            if (personFound.Company.Name!=null)
            {
                Console.WriteLine($"{personFound.Company.Name} {personFound.Company.Department} {personFound.Company.Salary:f2}");
            }
            Console.WriteLine("Car:");
            if (personFound.Car.Model != null)
            {
                Console.WriteLine($"{personFound.Car.Model} {personFound.Car.Speed}");
            }
            Console.WriteLine("Pokemon:");
            if (personFound.Pokemon.Count!=0)
            {
                foreach (var pokemon in personFound.Pokemon)
                {
                    Console.WriteLine($"{pokemon.Name} {pokemon.Type}");
                }
            }
            Console.WriteLine("Parents:");
            if (personFound.Parents.Count != 0)
            {
                foreach (var pokemon in personFound.Parents)
                {
                    Console.WriteLine($"{pokemon.Name} {pokemon.BirthDay}");
                }
            }
            Console.WriteLine("Children:");
            if (personFound.Children.Count != 0)
            {
                foreach (var pokemon in personFound.Children)
                {
                    Console.WriteLine($"{pokemon.Name} {pokemon.BirthDay}");
                }
            }

        }
    }
}
