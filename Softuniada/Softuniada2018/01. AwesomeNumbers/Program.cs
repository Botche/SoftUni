using System;

namespace AwesomeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int numberToDivide = int.Parse(Console.ReadLine());

            int level = 0;
            if(Math.Abs(number)%2==1)
            {
                level++;
            }

            if(number<0)
            {
                level++;
            }

            if(number%numberToDivide==0)
            {
                level++;
            }

            switch (level)
            {
                case 0:
                    Console.WriteLine("boring");
                    break;
                case 1:
                    Console.WriteLine("awesome");
                    break;
                case 2:
                    Console.WriteLine("super awesome");
                    break;
                case 3:
                    Console.WriteLine("super special awesome");
                    break;
            }
        }
    }
}
