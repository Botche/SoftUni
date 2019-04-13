using System;
namespace toyShop
{
    class System
    {
        static void Main()
        {
            double sum1 = double.Parse(Console.ReadLine());
            int puz = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            int tracks = int.Parse(Console.ReadLine());
            double sum;
            sum = puz * 2.6 + dolls * 3 + bears * 4.1 + min * 8.2 + tracks * 2;
            if ((puz + dolls + bears + min + tracks) >= 50)
                sum = sum - sum / 4;
            sum = sum - sum / 10;
            if ((sum - sum1) >= 0)
                Console.WriteLine($"Yes! {(sum - sum1):f2} lv left.");
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(sum - sum1):f2} lv needed.");
            }
        }
    }
}
