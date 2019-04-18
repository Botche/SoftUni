using System;

namespace salary
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            for(var i=0;i<n;i++)
            {
                string tab = Console.ReadLine();
                if (tab == "Facebook")
                    salary -= 150;
                if (tab == "Instagram")
                    salary -= 100;
                if (tab == "Reddit")
                    salary -= 50;
                if(salary<=0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if(salary>0)
                Console.WriteLine(salary);
        }
    }
}
