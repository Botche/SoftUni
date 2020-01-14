using System;

namespace dataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            switch(dataType)
            {
                case "int":
                    int number = int.Parse(Console.ReadLine());
                    IntFormat(number);
                    break;
                case "real":
                    double num = double.Parse(Console.ReadLine());
                    DoubleFormat(num);
                    break;
                case "string":
                    string str = Console.ReadLine();
                    StringFormat(str);
                    break;
            }
        }

        private static void StringFormat(string str)
        {
            Console.WriteLine($"${str}$");
        }

        private static void DoubleFormat(double num)
        {
            Console.WriteLine($"{num*1.5:f2}");
        }

        private static void IntFormat(int number)
        {
            Console.WriteLine(number*2);
        }
    }
}
