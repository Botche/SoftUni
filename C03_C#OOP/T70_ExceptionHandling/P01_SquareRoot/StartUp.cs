using System;

namespace P01_SquareRoot
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var number = double.Parse(Console.ReadLine());

            try
            {
                var squareRoot = Math.Sqrt(number);

                Console.WriteLine($"{squareRoot:f2}");
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
