using System;

namespace beerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0, maxSum = double.MinValue;string typeOfKeg1="";
            for (int i = 0; i < n; i++)
            {
                string typeOfKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                sum = (Math.PI * radius * radius) * height;
                if (maxSum < sum)
                {
                    typeOfKeg1 = typeOfKeg;
                    maxSum = sum;
                }
            }
            Console.WriteLine(typeOfKeg1);
        }
    }
}
