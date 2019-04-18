using System;

namespace graduation
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            double count = 1, sum=0;
            while (count<=12)
            {
                double a = double.Parse(Console.ReadLine());
                sum += a;
                count++;
            }
            sum /= 12;
            if(sum>=4)
                Console.WriteLine($"{name} graduated. Average grade: {sum:f2}");
            else
                Console.WriteLine($"{name} will repeat the class");
        }
    }
}
