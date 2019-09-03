using System;

namespace P04_FixingVol2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int num1 = 30;
            int num2 = 60;

            try
            {
                var result = Convert.ToByte(num1 * num2);

                Console.WriteLine(result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Stack overflowed");
            }
        }
    }
}
