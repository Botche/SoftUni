using System;

namespace P05_ConvertToDouble
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var value = Console.ReadLine();
            double result = 0;

            try
            {
                result = Convert.ToDouble(value);
                Console.WriteLine("Converted '{0}' to {1}.", value, result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}' to a Double.", value);
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is outside the range of a Double.", value);
            }
        }
    }
}
