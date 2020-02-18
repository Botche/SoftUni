using System;

namespace savePasswordGenerator
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int counter = 0;
            char c = '#', d = '@';
            for(var i=1;i<=a;i++)
            {
                for(var j=1;j<=b;j++)
                {
                    Console.Write($"{c}{d}{i}{j}{d}{c}|");
                    c++;
                    d++;
                    counter++;
                    if (c > 55)
                        c = '#';
                    if (d > 96)
                        d = '@';
                    if (counter == max)
                        return;
                }
            }
        }
    }
}
