using System;
namespace substitute
{
    class Program
    {
        static void Main()
        {
            int K = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int counter = 0;
            for(var i=K;i<=8;i++)
            {
                for(var j=9;j>=L;j--)
                {
                    for(var l=M;l<=8;l++)
                    {
                        for (var k = 9; k >= N; k--)
                        {
                            if (i % 2 == 0 && j % 2 != 0 && l % 2 == 0 && k % 2 != 0)
                            {
                                if (i == l && j == k)
                                    Console.WriteLine("Cannot change the same player.");
                                else
                                {
                                    Console.WriteLine($"{i}{j} - {l}{k}");
                                    counter++;
                                }
                            }
                            if (counter == 6)
                            break;
                        }
                        if (counter == 6)
                            break;
                    }
                    if (counter == 6)
                        break;
                }
                if (counter == 6)
                    break;
            }
        }
    }
}
