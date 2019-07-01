using System;

namespace smallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(ReturnSmallestNumber(num1,num2,num3));
        }

        private static int ReturnSmallestNumber(int num1, int num2, int num3)
        {
            int smallest = Math.Min(num1, num2);
            int smallest2 = Math.Min(num2, num3);
            if (smallest < smallest2)
                return smallest;
            else
                return smallest2;
        }
    }
}
