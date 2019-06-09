using System;
using System.Linq;

namespace _05._AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        nums = nums.Select(n => ++n).ToArray();
                        break;
                    case "multiply":
                        nums = nums.Select(n => n * 2).ToArray();
                        break;
                    case "subtract":
                        nums = nums.Select(n => --n).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", nums));
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
