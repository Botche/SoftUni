using System;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split();
            string[] secondInput = Console.ReadLine()
                .Split();
            string[] thirdInput = Console.ReadLine()
                .Split();

            string personName = firstInput[0] + " " + firstInput[1];
            string address = firstInput[2];

            string name = secondInput[0];
            int litresOfBeer = int.Parse(secondInput[1]);

            int num = int.Parse(thirdInput[0]);
            double doubleNum = double.Parse(thirdInput[1]);


            var firstTuple = new Tuple<string, string>(personName, address);
            var secondTuple = new Tuple<string, int>(name, litresOfBeer);
            var thirdTuple = new Tuple<int, double>(num, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
