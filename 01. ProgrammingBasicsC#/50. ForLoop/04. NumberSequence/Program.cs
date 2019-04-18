using System;

namespace numberSequence
{
    class Program
    {
        static void Main()
        {
            int smallest = int.MaxValue;

            int biggest = int.MinValue;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END") break;

                int num = int.Parse(command);

                if (num < smallest) smallest = num;

                if (num > biggest) biggest = num;

            }

            Console.WriteLine($"Max number: {biggest}");

            Console.WriteLine($"Min number: {smallest}");
        }
    }
}
