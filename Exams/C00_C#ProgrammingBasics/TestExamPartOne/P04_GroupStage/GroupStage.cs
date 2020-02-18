using System;

namespace groupStage
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            int counterPoints = 0, maxGoalIn = 0, maxGoalOut = 0;
            for(var i=0;i<n;i++)
            {
                int goalIn = int.Parse(Console.ReadLine());
                int goalOut = int.Parse(Console.ReadLine());
                if (goalIn > goalOut)
                    counterPoints += 3;
                else if (goalOut == goalIn)
                    counterPoints++;
                maxGoalIn += goalIn;
                maxGoalOut += goalOut;
            }
            if(maxGoalIn <= maxGoalOut)
            {
                Console.WriteLine($"{name} has finished the group phase with {counterPoints} points.");
                Console.WriteLine($"Goal difference: {maxGoalIn-maxGoalOut}.");
            }
            else
            {
                Console.WriteLine($"{name} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {maxGoalIn - maxGoalOut}.");
            }
        }
    }
}
