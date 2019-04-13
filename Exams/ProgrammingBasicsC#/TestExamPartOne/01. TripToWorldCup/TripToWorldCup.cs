using System;

namespace tripToWorldCup
{
    class Program
    {
        static void Main()
        {
            double goingsum = double.Parse(Console.ReadLine());//175
            double backingsum = double.Parse(Console.ReadLine());//280
            double matchsum = double.Parse(Console.ReadLine());//125
            double brmatch = double.Parse(Console.ReadLine());//5
            double pr = double.Parse(Console.ReadLine());//15
            double sum = (goingsum + backingsum) * 6;
            double sum1 = sum - sum * (pr / 100);
            double sumTotal = sum1 + brmatch * matchsum * 6;
            Console.WriteLine($"Total sum: {sumTotal:f2} lv.");
            Console.WriteLine($"Each friend has to pay {sumTotal/6:f2} lv.");
        }
    }
}
