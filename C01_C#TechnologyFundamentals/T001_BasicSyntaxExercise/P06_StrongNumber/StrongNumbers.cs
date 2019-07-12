using System;

namespace strongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int num1 = 0, sum = 1, allSum = 0;
            int oldNum = num;
            while (num > 0)
            {
                sum = 1;
                num1 = num % 10;
                num /= 10;
                for (int j = 1; j <= num1; j++)
                    sum *= j;
                allSum += sum;
            }
            if (oldNum == allSum)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
