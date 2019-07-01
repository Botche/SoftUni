using System;

namespace refactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
            double dul = 0;
            dul = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double sh = 0;
            sh = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double h = 0;
            h = double.Parse(Console.ReadLine());
            double V = 0;
            V = dul * sh * h / 3;
            Console.WriteLine("Pyramid Volume: {0:F2}", V);
        }
    }
}
