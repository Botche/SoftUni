using System;

namespace FirstSol
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int groupCount = int.Parse(Console.ReadLine());
            double fuelPerKm = double.Parse(Console.ReadLine());
            double foodExp = double.Parse(Console.ReadLine());
            double priceForRoom = double.Parse(Console.ReadLine());


            double sum = 0;
            sum += foodExp * groupCount * days;
            double totalHotelExp = priceForRoom * groupCount * days;
            if (groupCount > 10)
                totalHotelExp *= 0.75;
            sum += totalHotelExp;
            for (int day = 1; day <= days; day++)
            {
                double tralledDistance = double.Parse(Console.ReadLine());
                sum += tralledDistance * fuelPerKm;
                if (day % 3 == 0 || day % 5 == 0)
                {
                    sum += sum * 0.4;
                }
                if (sum > budget)
                {
                    break;
                }
                if (day % 7 == 0)
                    sum -= sum / groupCount;
            }
            if (sum > budget)
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {sum - budget:f2}$ more.");
            }
            else
            {
                Console.WriteLine($"You have reached the destination. You have {budget - sum:f2}$ budget left.");
            }
        }
    }
}
