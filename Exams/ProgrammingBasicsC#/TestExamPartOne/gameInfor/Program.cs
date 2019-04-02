using System;


namespace gameInfor
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            double br = double.Parse(Console.ReadLine());
            double counterP = 0, sumAll = 0, sum = 0,counter=0;
            for(var i=0;i<br;i++)
            {
                int min = int.Parse(Console.ReadLine());
                if (min > 90 && min<=120)
                    counter++;
                if (min > 120)
                    counterP++;
                sumAll += min;
            }
            Console.WriteLine($"{name} has played {sumAll} minutes. Average minutes per game: {sumAll / br:f2}");
            Console.WriteLine($"Games with penalties: {counterP}");
            Console.WriteLine($"Games with additional time: {counter}");
        }
    }
}
