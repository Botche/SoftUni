using System;

namespace recursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibonacci = int.Parse(Console.ReadLine());
            int a = 0;
            int b = 1;
            for (int i = 0; i < fibonacci; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            Console.WriteLine(b);
        }
    }
}
