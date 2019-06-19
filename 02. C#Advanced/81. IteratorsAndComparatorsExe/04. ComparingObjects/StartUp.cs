using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = null;

            while ((input=Console.ReadLine())!="END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            int countOfMatches = 0;
            int countOfNotEqualPeople = 0;

            Person targetPerson = people[n - 1];

            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson)==0)
                {
                    countOfMatches++;
                }
                else
                {
                    countOfNotEqualPeople++;
                }
            }

            if (countOfMatches==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {countOfNotEqualPeople} {people.Count}");
            }
        }
    }
}
