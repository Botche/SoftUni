using System;
using System.Collections.Generic;
using System.Linq;

namespace OrdedByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Person> people = new List<Person>();

            while(input[0]!="End")
            {
                Person person = new Person();
                person.Name = input[0];
                person.ID = input[1];
                person.age = int.Parse(input[2]);
                people.Add(person);

                input = Console.ReadLine().Split();
            }

            List<Person> OrderedByAge = people.OrderBy(x => x.age).ToList();
            foreach ( var person in OrderedByAge)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.age} years old.");
            }
        }

        class Person
        {
           public string Name;
            public string ID;
            public int age;
        }
    }
}
