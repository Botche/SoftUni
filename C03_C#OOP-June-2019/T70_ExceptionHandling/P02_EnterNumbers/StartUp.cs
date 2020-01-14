using System;

namespace P02_EnterNumbers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int start = 0;
            int end = 100;

            while (true)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var number = ReadNumber(start, end);

                        start = number;
                    }

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static int ReadNumber(int start, int end)
        {
            var input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (number <= start || number >= end)
                {
                    throw new ArgumentException($"Numbers must be in specific order such that: 1 < a1 < ... < a10 < 100."
                        + Environment.NewLine+
                        "Start again...");
                }
            }
            else
            {
                throw new FormatException("Please enter a integer");
            }

            return number;
        }
    }
}
