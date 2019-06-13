using System;

namespace Threeuple
{
    class Program
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
            string town = firstInput[3];

            string name = secondInput[0];
            int litresOfBeer = int.Parse(secondInput[1]);
            bool isDrunk = (secondInput[2] == "drunk") ? true : false;

            string nameTwo = thirdInput[0];
            double doubleNum = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];

            var firstTuple = new Tuple<string, string,string>(personName, address,town);
            var secondTuple = new Tuple<string, int,bool>(name, litresOfBeer,isDrunk);
            var thirdTuple = new Tuple<string, double,string>(nameTwo, doubleNum,bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
