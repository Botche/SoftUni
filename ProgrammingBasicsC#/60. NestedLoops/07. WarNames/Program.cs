using System;

namespace warNames
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int max = int.MinValue;
            int sum = 0;
            string winner = string.Empty;
            while(name!="STOP")
            {
                for (int i = 0; i < name.Length; i++)
                    sum += (int)name[i];
                if (sum > max)
                {
                    max = sum;
                    winner = $"Winner is {name} - {max}!";
                }
                name = Console.ReadLine();
                sum = 0;
            }
            Console.WriteLine(winner);
        }
    }
}
