using System;

namespace building
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            for(int i=n;i>0;i--)
            {
                for(int j=0;j<m;j++)
                {
                    if(i==n)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else if(i%2==0) 
                        Console.Write($"O{i}{j} ");
                    else
                        Console.Write($"A{i}{j} ");
                }
            Console.WriteLine();
            }
        }
    }
}
