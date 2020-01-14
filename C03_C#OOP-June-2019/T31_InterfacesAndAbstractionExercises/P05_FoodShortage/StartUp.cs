using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    var rebel = new Rebel(name, age, group);

                    rebels.Add(rebel);
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthDay = input[3];

                    var citizen = new Citizen(name, age, id, birthDay);

                    citizens.Add(citizen);
                }
            }
            string command = string.Empty;
            while ((command=Console.ReadLine())!="End")
            {
                string name = command;

                var citizen = citizens.FirstOrDefault(c => c.Name == name);
                var rebel = rebels.FirstOrDefault(c => c.Name == name);

                if (citizen!=null)
                {
                    citizen.BuyFood();
                }
                if (rebel!=null)
                {
                    rebel.BuyFood();
                }
            }

            int food = 0;
            food += citizens.Sum(c => c.Food);
            food += rebels.Sum(c => c.Food);

            Console.WriteLine(food);
        }
    }
}
