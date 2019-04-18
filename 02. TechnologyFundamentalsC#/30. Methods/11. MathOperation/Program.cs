using System;

namespace mathOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            char mathOperation = char.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double sumOfOperation=0;
            if(mathOperation=='+')
            {
                sumOfOperation=Add(num1, num2);
            }
            else if (mathOperation == '-')
            {
                sumOfOperation = Substract(num1, num2);
            }
            else if (mathOperation == '*')
            {
                sumOfOperation = Multiply(num1, num2);
            }
            else if (mathOperation == '/')
            {
                sumOfOperation = Divide(num1, num2);
            }
            Console.WriteLine(Math.Round(sumOfOperation,2));
        }

        private static double Divide(double num1, double num2)
        {
            double sum = num1 / num2;
            return sum;
        }

        private static double Multiply(double num1, double num2)
        {
            double sum = num1 * num2;
            return sum;
        }

        private static double Substract(double num1, double num2)
        {
            double sum = num1 - num2;
            return sum;
        }

        private static double Add(double num1, double num2)
        {
            double sum = num1 + num2;
            return sum;
        }
    }
}
