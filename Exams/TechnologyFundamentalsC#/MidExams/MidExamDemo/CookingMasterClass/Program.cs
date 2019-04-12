using System;

namespace CookingMasterClass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfFloor = double.Parse(Console.ReadLine());
            double priceOfEggs = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine());

            double sumOfFloor = priceOfFloor * (students - students / 5);
            double sumOfEggs = priceOfEggs * students *10;
            double sumOfApron = priceOfApron * Math.Ceiling(students+students*0.20);
            double sum = sumOfApron + sumOfEggs + sumOfFloor;
            if (sum <= budget)
            {
                Console.WriteLine($"Items purchased for {sum:f2}$.");
            }
            else
                Console.WriteLine($"{sum-budget:f2}$ more needed.");
        }
    }
}
