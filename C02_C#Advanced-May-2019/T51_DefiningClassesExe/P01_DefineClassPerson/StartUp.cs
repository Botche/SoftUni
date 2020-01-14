using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name,age);

                family.AddMember(person);
            }

            family.PrintOlderThan30();
        }
    }
}
