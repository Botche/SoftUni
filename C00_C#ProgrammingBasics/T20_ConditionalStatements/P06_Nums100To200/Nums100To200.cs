using System;
namespace Nums100to200
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            if(a<100)
                Console.WriteLine("Less than 100");
            else
            {
                if(a>200)
                    Console.WriteLine("Greater than 200");
                else Console.WriteLine("Between 100 and 200");
            }
        }
    }
}
