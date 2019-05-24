using System;

namespace waterDispenser
{
    class Program
    {
        static void Main()
        {
            int v = int.Parse(Console.ReadLine());
            int sum = 0,counter=0;
            string button;
            while(sum<=v)
            {
                button = Console.ReadLine();
                if (button == "Easy")
                    sum += 50;//sum = sum + 50;
                else if(button == "Medium")
                    sum += 100;
                else if(button=="Hard")
                    sum += 200;
                counter++;
                if (sum == v)
                {
                    Console.WriteLine($"The dispenser has been tapped {counter} times.");
                    break;
                }
                else if (sum > v)
                {
                    Console.WriteLine($"{sum - v}ml has been spilled.");
                    break;
                }
            }
            
        }
    }
}
