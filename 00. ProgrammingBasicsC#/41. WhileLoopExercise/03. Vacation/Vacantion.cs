using System;

namespace vacantion
{
    class Program
    {
        static void Main()
        {
            double money = double.Parse(Console.ReadLine());
            double saving = double.Parse(Console.ReadLine());
            int counter = 0, days = 0;
            while (true)
            {
                string command = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());
                days++;
                if(command=="spend")
                {
                    counter++;
                    if (sum > saving)
                        saving = 0;
                    else
                        saving -= sum;
                    if(counter==5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(days);
                        break;
                    }
                    
                }
                else if(command=="save")
                {
                    counter = 0;
                    saving += sum;
                    if (saving >= money)
                    {
                        Console.WriteLine($"You saved the money for {days} days.");
                        break;
                    }
                }
            }

        }
    }
}
