using System;
using System.Collections.Generic;

namespace _05._FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();
            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, age);
                }
            }

            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());

            Dictionary<string, int> filtheredPeople = new Dictionary<string, int>();
            filtheredPeople=FilterPeopleByAge(people, condition, ageCondition);

            string[] format = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (format.Length==1)
            {
                if (format[0]=="age")
                {
                    foreach (var (person,age) in filtheredPeople)
                    {
                        Console.WriteLine(age);
                    }
                }
                else if (format[0]=="name")
                {
                    foreach (var (person, age) in filtheredPeople)
                    {
                        Console.WriteLine(person);
                    }
                }
            }
            else
            {
                foreach (var (person, age) in filtheredPeople)
                {
                    Console.WriteLine($"{person} - {age}");
                }
            }
        }

        private static Dictionary<string, int> FilterPeopleByAge(Dictionary<string, int> people, string condition, int ageCondition)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            if (condition == "younger")
            {
                foreach (var (person,age) in people)
                {
                    if (age<ageCondition)
                    {
                        if (!dict.ContainsKey(person))
                        {
                            dict.Add(person, age);
                        }
                    }
                }
            }
            else if (condition=="older")
            {
                foreach (var (person, age) in people)
                {
                    if (age >= ageCondition)
                    {
                        if (!dict.ContainsKey(person))
                        {
                            dict.Add(person, age);
                        }
                    }
                }
            }
            return dict;
        }
    }
}
