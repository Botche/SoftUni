using System;

namespace spiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSpices = int.Parse(Console.ReadLine());
            int sumOfSpicess = 0, counter = 0;
            while (numberOfSpices >= 100)
            {
                sumOfSpicess += numberOfSpices - 26;
                numberOfSpices -= 10;
                counter++;
            }
            if (sumOfSpicess - 26 < 0)
                sumOfSpicess = 0;
            else
                sumOfSpicess -= 26;
            Console.WriteLine(counter);
            Console.WriteLine(sumOfSpicess);
        }
    }
}
