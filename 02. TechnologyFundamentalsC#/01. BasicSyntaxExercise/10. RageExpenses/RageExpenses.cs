using System;

namespace rageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGameCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double screenPrice = double.Parse(Console.ReadLine());
            int brokenH, brokenM, brokenK, brokenS;
            brokenH = lostGameCount / 2;
            brokenM = lostGameCount / 3;
            brokenK = lostGameCount / 6;
            brokenS = lostGameCount / 12;
            double sum = brokenS * screenPrice + brokenM * mousePrice + brokenK * keyboardPrice + brokenH * headsetPrice;
            Console.WriteLine($"Rage expenses: {sum:F2} lv.");
            
        }
    }
}
