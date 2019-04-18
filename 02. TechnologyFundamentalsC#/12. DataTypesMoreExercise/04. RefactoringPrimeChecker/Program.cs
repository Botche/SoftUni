using System;

namespace refactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int i = 0;int j = 0;
            for( i=2;i<=n;i++)
            {
                bool b = true;
                for( j=2;j<i;j++)
                {
                    if(i%j==0)
                    {
                        b = false;
                        break;
                    }
                    
                }Console.WriteLine($"{i} -> {b.ToString().ToLower()}");
            }
            
        }
    }
}
