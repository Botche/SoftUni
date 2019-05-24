using System;

namespace padawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int countStudent = int.Parse(Console.ReadLine());
            double priceOfLightsabers = double.Parse(Console.ReadLine());
            double priceOfRobes = double.Parse(Console.ReadLine());
            double priceOfBelts = double.Parse(Console.ReadLine());
            double sumAll = 0, sumOfL = 0, sumOfR = 0, SumOfB = 0;
            sumOfL = priceOfLightsabers * (countStudent + Math.Ceiling(countStudent * 0.10));
            double freeB = countStudent / 6;
            SumOfB = priceOfBelts * (countStudent - freeB);
            sumOfR = priceOfRobes * countStudent;
            sumAll = SumOfB + sumOfL + sumOfR;
            if (money >= sumAll)
                Console.WriteLine($"The money is enough - it would cost {sumAll:f2}lv.");
            else
                Console.WriteLine($"Ivan Cho will need {sumAll-money:f2}lv more.");
        }
    }
}
