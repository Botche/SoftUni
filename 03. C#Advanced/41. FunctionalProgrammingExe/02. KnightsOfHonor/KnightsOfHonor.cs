using System;

namespace _02._KnightsOfHonor
{
    class Program
    {
        public static Action<string> action = p => Console.WriteLine($"Sir {p}");
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in people)
            {
                action(person);
            }
        }
    }
}
