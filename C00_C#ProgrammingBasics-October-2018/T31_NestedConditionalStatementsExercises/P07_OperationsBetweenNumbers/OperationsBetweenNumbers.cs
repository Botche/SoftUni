using System;

namespace operationsBetweenNumbers
{
    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            string c = Console.ReadLine();

            if (c == "+")
            {
                if ((a + b) % 2 == 0)
                    Console.WriteLine($"{a} {c} {b} = {a + b} - even");
                else
                    Console.WriteLine($"{a} {c} {b} = {a + b} - odd");
            }
            else if (c == "-")
            {
                if ((a - b) % 2 == 0)
                    Console.WriteLine($"{a} {c} {b} = {a - b} - even");
                else
                    Console.WriteLine($"{a} {c} {b} = {a - b} - odd");
            }
            else if (c == "*")
            {
                if ((a * b) % 2 == 0)
                    Console.WriteLine($"{a} {c} {b} = {a * b} - even");
                else
                    Console.WriteLine($"{a} {c} {b} = {a * b} - odd");
            }
            else if (c == "/")
            {
                if (b == 0)
                    Console.WriteLine($"Cannot divide {a} by zero");
                else
                    Console.WriteLine($"{a} {c} {b} = {a / b:f2}");
            }
            else
            {
                if (b == 0)
                    Console.WriteLine($"Cannot divide {a} by zero");
                else
                    Console.WriteLine($"{a} {c} {b} = {a % b}");
            }
        }
    }
}
