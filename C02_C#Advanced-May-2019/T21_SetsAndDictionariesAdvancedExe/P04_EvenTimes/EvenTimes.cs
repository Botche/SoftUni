using System;
using System.Collections.Generic;

namespace _04._EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Dictionary<int, int> counterOfNumbers = new Dictionary<int, int>();

            for (int i = 0; i < length; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!counterOfNumbers.ContainsKey(num))
                {
                    counterOfNumbers.Add(num, 0);
                }
                counterOfNumbers[num]++;
            }

            foreach (var num in counterOfNumbers)
            {
                if (num.Value%2==0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}
