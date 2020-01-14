using System;

namespace FerrariProblem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var driverName = Console.ReadLine();

            var ferrari = new Ferrari(driverName);

            Console.WriteLine($"{ferrari.Model}/{ferrari.Break()}/{ferrari.Gas()}/{ferrari.Name}");
        }
    }
}
