using System;
namespace evenFigures
{
    class Program
    {
        static void Main()
        {
            string a = Console.ReadLine();
            double area;
            if (a == "square")
            {
                double b = double.Parse(Console.ReadLine());
                area = b * b;
                Console.WriteLine(area);
            }
            else {
                if (a == "rectangle")
                {
                    double b = double.Parse(Console.ReadLine());
                    double c = double.Parse(Console.ReadLine());
                    area = b * c;
                    Console.WriteLine(area);
                }
                if (a == "circle")
                {
                    double r = double.Parse(Console.ReadLine());
                    area = Math.Pow(r, 2) * Math.PI;
                    Console.WriteLine(area);
                }
                if (a == "triangle")
                {
                    double c = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    area = c * b / 2;
                    Console.WriteLine(area);
                }
            }
            
        }
    }
}
