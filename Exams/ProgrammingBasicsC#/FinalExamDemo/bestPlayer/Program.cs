using System;

namespace bestPlayer
{
    class Program
    {
        static void Main()
        {
            string name = "";
            int goals = 0;
            int max = int.MinValue;
            string bestPlayer = "";
            while(true)
            {
                name = Console.ReadLine();
                if (name == "END")
                    break;
                goals = int.Parse(Console.ReadLine());
                if (max < goals)
                {
                    bestPlayer = name;
                    max = goals;
                }
                if (goals >= 10)
                    break;
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (max >= 3)
                Console.WriteLine($"He has scored {max} goals and made a hat-trick !!!");
            else
                Console.WriteLine($"He has scored {max} goals.");
        }
    }
}
