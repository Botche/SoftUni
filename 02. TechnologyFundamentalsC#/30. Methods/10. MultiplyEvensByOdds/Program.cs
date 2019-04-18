using System;

namespace multiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            num = Math.Abs(num);
            GetMultiplyOfEvensByOdds(num);
        }

        private static void GetMultiplyOfEvensByOdds(int num)
        {
            Console.WriteLine(GetSumOfEvens(num)*GetSumOfOdds(num));
        }

        private static int GetSumOfEvens(int num)
        {
            int sumOfEvens = 0;
            while (num>0)
            {
                int lastDigit = num % 10;
                if (lastDigit % 2 == 0)
                    sumOfEvens += lastDigit;
                num /= 10;
            }
            return sumOfEvens;
        }

        private static int GetSumOfOdds(int num)
        {
            int sumOfOdds = 0;
            while (num > 0)
            {
                int lastDigit = num % 10;
                if (lastDigit % 2 == 1)
                    sumOfOdds += lastDigit;
                num /= 10;
            }
            return sumOfOdds;
        }
    }
}
