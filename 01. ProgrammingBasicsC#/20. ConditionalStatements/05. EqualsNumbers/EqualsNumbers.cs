using System;
namespace equalsNumbers
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            if (a == b && a == c && b == c)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
