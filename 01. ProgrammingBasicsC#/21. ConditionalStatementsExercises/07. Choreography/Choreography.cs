using System;


namespace choreography
{
    class Program
    {
        static void Main()
        {
            double steps = double.Parse(Console.ReadLine());
            double dancers = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());
            double pr,prd;
            pr = ((steps / days) / steps) * 100;
            pr = Math.Ceiling(pr);
            prd = pr / dancers;
            if(pr<=13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {prd:f2}%.");

            }
            else
                Console.WriteLine($"No, They will not succeed in that goal! Required {prd:f2}% steps to be learned per day.");
            Console.ReadKey();
        }
    }
}
