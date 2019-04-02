using System;

namespace BeerAndChips
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            double money = double.Parse(Console.ReadLine());//5
            int brbottles = int.Parse(Console.ReadLine());//2
            int brchips = int.Parse(Console.ReadLine());//4
            double sumbottles = brbottles * 1.20;//2.40
            double sumchips = Math.Ceiling(0.45 * sumbottles*brchips);//5
            if (money >= (sumbottles + sumchips))//5<7.40
                Console.WriteLine($"{name} bought a snack and has {money - (sumchips + sumbottles):f2} leva left.");
            else
                Console.WriteLine($"{name} needs {Math.Abs(money - (sumchips + sumbottles)):f2} more leva!");
        }
    }
}
