using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            var Dolar = double.Parse(Console.ReadLine());
            double Levche;
            Levche = Dolar * 1.79549;
            Console.WriteLine($"{Levche:f2}");
        }
    }
}
