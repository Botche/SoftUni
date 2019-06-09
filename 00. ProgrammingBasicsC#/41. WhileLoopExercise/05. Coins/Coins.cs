using System;

namespace coins
{
    class Program
    {
        static void Main()
        {
            double coins = double.Parse(Console.ReadLine());
            int counter=0;
            while(coins>=2)
            {
                coins = coins - 2;
                counter++;
            }
            if(coins>=1 && coins<2)
            {
                coins = coins - 1;
                counter++;
            }
           if(coins>=0.50 && coins < 1)
            {
                coins = coins - 0.50;
                 counter++;
            }
            if(coins>=0.20 && coins < 0.50)
            {
                coins = coins - 0.20;
                 counter++;
            }
            if (coins >= 0.20 && coins < 0.50)
            {
                coins = coins - 0.20;
                counter++;
            }
            if (coins>=0.10 && coins < 0.20)
            {
                coins = coins - 0.10;
                 counter++;
            }
            if(coins>=0.05 && coins < 0.10)
            {
                coins = coins - 0.05;
                 counter++;
            }
            if (coins >= 0.02 && coins < 0.05)
            {
                coins = coins - 0.02;
                 counter++;
            }
            if (coins >= 0.02 && coins < 0.05)
            {
                coins = coins - 0.02;
                counter++;
            }
            if (coins >= 0.01 && coins < 0.02)
            {
                coins = coins - 0.01;
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
