using System;

namespace invalidNumber
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            if(a<100 || a>200)
            {
                if(a!=0)
                    Console.WriteLine("invalid");
            }
        }
    }
}
