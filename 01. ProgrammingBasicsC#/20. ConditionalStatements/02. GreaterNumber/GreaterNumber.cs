using System;

namespace greaterNumber
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (a < b)
                Console.WriteLine(b);
            else
                Console.WriteLine(a);
        }
    }
}
