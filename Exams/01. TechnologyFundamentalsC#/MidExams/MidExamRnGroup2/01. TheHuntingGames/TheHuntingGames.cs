using System;

namespace TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int countOfPlayers = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterNeededForOneDayPerP = double.Parse(Console.ReadLine());
            double foodNeededForOneDayPerP = double.Parse(Console.ReadLine());

            double totalWater = days * countOfPlayers * waterNeededForOneDayPerP;
            double totalFood = days * countOfPlayers * foodNeededForOneDayPerP;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());

                groupEnergy -= energyLoss;
                if (groupEnergy <= 0)
                    break;

                if (i%2==0)
                {
                    groupEnergy += groupEnergy * 0.05;
                    totalWater *= 0.70;
                }

                if (i%3==0)
                {
                    groupEnergy += groupEnergy * 0.10;
                    totalFood -= totalFood / countOfPlayers;
                }
            }

            if (groupEnergy <= 0)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }
            else
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }
        }
    }
}
