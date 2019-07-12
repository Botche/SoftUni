using System;

namespace _01._ActionPrint
{
    class Program
    {
        public static Action<string> action = p => Console.WriteLine(p);
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
