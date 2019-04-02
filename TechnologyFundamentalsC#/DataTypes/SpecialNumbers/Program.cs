using System;

namespace specialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 0;int sum = 0;int num1 = 0;
            for(int i=1;i<=n;i++)
            {
                num = i;sum = 0;
                while(num>0)
                {
                    num1 = num % 10;
                    sum += num1;
                    num /= 10;
                }
                if (sum == 5 || sum == 7  || sum == 11 )
                    Console.WriteLine($"{i} -> True");
                else
                    Console.WriteLine($"{i} -> False");
                
            }
        }
    }
}
