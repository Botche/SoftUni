using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            List<int> secondHand = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            while (firstHand.Count!=0 && secondHand.Count != 0)
            {
                if(firstHand[0]==secondHand[0])
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
                else if(firstHand[0] < secondHand[0])
                {
                    secondHand.Add(secondHand[0]);
                    secondHand.RemoveAt(0);
                    secondHand.Add(firstHand[0]);
                    firstHand.RemoveAt(0);
                }
                else
                {
                    firstHand.Add(firstHand[0]);
                    firstHand.RemoveAt(0);
                    firstHand.Add(secondHand[0]);
                    secondHand.RemoveAt(0);
                }
            }
            if(firstHand.Sum()<secondHand.Sum())
                Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
            else
                Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
        }
    }
}
