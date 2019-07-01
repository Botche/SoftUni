using System;

namespace numbersEndingIn7
{
    class Program
    {
        static void Main()
        {
            for(var i=7;i<=997;i++)
            {
                if(i % 10==7)
                    Console.WriteLine(i);
            }
        }
    }
}
