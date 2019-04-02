using System;

namespace multyplyTable
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int a, b, c;
            a = n % 10;
            b = n / 10 % 10;
            c = n / 100;
            for(var i=1;i<=a;i++)
            {
                for (var j = 1; j <= b; j++)
                {
                    for (var k = 1; k <= c; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i*j*k};");
                    }
                }
            }
        }
    }
}
