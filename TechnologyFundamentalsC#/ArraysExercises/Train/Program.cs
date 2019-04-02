using System;

namespace train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] train = new int[wagons];
            int sum = 0;
            for (int i = 0; i < wagons; i++)
            {
                int peopleIncome = int.Parse(Console.ReadLine());
                train[i] = peopleIncome;
                sum += peopleIncome;
            }
            for (int i = 0; i < wagons; i++)
            {
                Console.Write(train[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
