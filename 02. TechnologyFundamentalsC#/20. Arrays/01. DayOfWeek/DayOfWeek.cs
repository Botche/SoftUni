using System;

namespace dayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int dayNumber = int.Parse(Console.ReadLine());
            if (dayNumber >= 1 && dayNumber <= 7)
                Console.WriteLine(daysOfWeek[dayNumber - 1]);
            else
                Console.WriteLine("Invalid day!");
        }
    }
}
