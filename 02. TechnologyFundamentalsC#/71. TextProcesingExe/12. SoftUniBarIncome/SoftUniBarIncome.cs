using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Regex pattern = new Regex(@"%(?<name>([A-z][a-z]+))%[^|$%.]*?<(?<product>(\w+))>[^|$%.]*?\|(?<quantity>\d+)\|[^|$%.]*?(?<productPrice>\d+\.?\d+)\$");
            double totalSum = 0;
            while (str!="end of shift")
            {
                MatchCollection matches = pattern.Matches(str);

                foreach (Match match in matches)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double productPrice = double.Parse(match.Groups["productPrice"].Value);

                    if(name!=null &&
                        product != null &&
                        quantity != 0 &&
                        productPrice != 0)
                    {
                        Console.WriteLine($"{name}: {product} - {productPrice*quantity:f2}");
                        double totalSumOfClient = productPrice * quantity;
                        totalSum += totalSumOfClient;
                    }
                }
                str = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
