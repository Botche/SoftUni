using System;

namespace projectPrize
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());
            double sum = 0;
            for(var i=1;i<=n;i++)
            {
                int P = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                    P = P * 2;
                sum += P;
            }
            Console.WriteLine($"The project prize was {sum*money:f2} lv.");
        }
    }
}
