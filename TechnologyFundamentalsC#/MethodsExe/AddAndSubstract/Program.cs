using System;

namespace addAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());


            SubstractThirdNumFromSum(num3, SumFirstTwoNums(num1, num2));
        }

        private static void SubstractThirdNumFromSum(int num3, int sum)
        {
            Console.WriteLine(sum-num3);
        }

        private static int SumFirstTwoNums(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
