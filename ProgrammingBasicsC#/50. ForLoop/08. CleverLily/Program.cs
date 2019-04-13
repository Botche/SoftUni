using System;

namespace cleverLily
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double sumP = double.Parse(Console.ReadLine());
            int price = int.Parse(Console.ReadLine());
            double sum = 0.00,counter=10.00;
            for(int i=0;i<n;i++)
            {
                if ((i+1) % 2 == 0)
                {
                    sum = sum + counter - 1.00;
                    counter += 10;
                } 
                else
                    sum += price;
                
            }
            if(sumP<=sum)
                Console.WriteLine($"Yes! {sum-sumP:f2}");
            else
                Console.WriteLine($"No! {sumP-sum:f2}");
        }
    }
}
