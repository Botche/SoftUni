using System;

namespace bus
{
    class Program
    {
        static void Main()
        {
            int brP = int.Parse(Console.ReadLine());
            int brS = int.Parse(Console.ReadLine());

            for (var i = 0; i < brS; i++)
            {
                int brOut = int.Parse(Console.ReadLine());
                int brIn = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    brP += 2;
                }
                else
                    brP -= 2;
                brP = brP - brOut + brIn;
            }
            Console.WriteLine($"The final number of passengers is : {brP}");
        }
    }
}
