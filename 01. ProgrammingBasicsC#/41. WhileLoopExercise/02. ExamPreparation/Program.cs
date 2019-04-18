using System;

namespace examPreparation
{
    class Program
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            double counter = 0,sum=0,counter1=0,ave=0;
            string com,command="0";
            while(true)
            {
                com = command;
                command = Console.ReadLine();
                
                if(command=="Enough")
                {
                    ave = sum / counter1;
                    Console.WriteLine($"Average score: {ave:f2}");
                    Console.WriteLine($"Number of problems: {counter1}");
                    Console.WriteLine($"Last problem: {com}");
                    break;
                }

                int mark = int.Parse(Console.ReadLine());
                sum += mark;
                counter1++;
                
                if(mark<=4)
                {
                    counter++;
                    if (counter == n)
                    {
                        Console.WriteLine($"You need a break, {counter} poor grades.");
                        break;
                    }
                }
            }
        }
    }
}
