using System;

namespace calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string mathAction = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            DoTheMathAction(mathAction, num1, num2);
        }

        private static void DoTheMathAction(string mathAction, int num1, int num2)
        {
            if (mathAction == "add")
                Add(num1, num2);
            else if (mathAction == "divide")
                Divide(num1, num2);
            else if (mathAction == "substract")
                Substract(num1, num2);
            else
                Multiply(num1, num2);
        }

        private static void Multiply(int num1, int num2)
        {
            int multiply = num1 * num2;
            Console.WriteLine(multiply);

        }

        private static void Substract(int num1, int num2)
        {
            int substract = num1 - num2;
            Console.WriteLine(substract);
        }

        private static void Divide(int num1, int num2)
        {
            double divide = num1 / num2;
            Console.WriteLine(divide);

        }

        private static void Add(int num1, int num2)
        {
            int add = num1 + num2;
            Console.WriteLine(add);
        }
    }
}
