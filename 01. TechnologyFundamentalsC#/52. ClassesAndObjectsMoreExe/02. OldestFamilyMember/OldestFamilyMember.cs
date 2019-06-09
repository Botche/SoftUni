using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int familyMembers = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            
            for (int i = 0; i < familyMembers; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                Person person = new Person();
                person.Name = input[0];
                person.Age = int.Parse(input[1]);

                people.Add(person);
            }
            var oldest = people.OrderByDescending(x => x.Age).ToList();
            Console.WriteLine(oldest[0].Name + " " + oldest[0].Age);
        }
    }

    class Person
    {
        public string Name;
        public int Age;
    }
}
