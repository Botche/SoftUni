using System;

namespace worldRecord
{
    class Program
    {
        static void Main()
        {
            double s = double.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            double sm = double.Parse(Console.ReadLine());
            double time,time1;
            time = m * sm;
            time1 = Math.Floor(m / 15) * 12.5;
            if ((time + time1) >= s)
                Console.WriteLine($"No, he failed! He was {(time + time1 - s):f2} seconds slower.");
            else
                Console.WriteLine($"Yes, he succeeded! The new world record is {(time + time1):f2} seconds.");
            Console.ReadKey();
        }
        
    }
}
