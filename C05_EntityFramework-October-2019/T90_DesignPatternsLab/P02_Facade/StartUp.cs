using System;

namespace P02_Facade
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                   .Info
                       .WithType("Honda")
                       .WithColor("Red")
                       .WithNumberOfDoors(5)
                   .Built
                       .InCity("Karlovo")
                       .AtAddress("Yumruk-Chal 1")
                   .Build();

            Console.WriteLine(car);
        }
    }
}
