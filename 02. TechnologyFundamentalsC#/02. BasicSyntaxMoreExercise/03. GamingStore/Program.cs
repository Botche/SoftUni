using System;

namespace gamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double spentSum = money;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${Math.Abs(money-spentSum):f2}. Remaining: ${money:F2}");
                    break;
                }
                else if (command == "OutFall 4")
                {
                    if (money < 39.99)
                        Console.WriteLine("Too Expensive");
                    else if (money - 39.99 == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        money -= 39.99;
                    }
                }
                else if (command == "CS: OG")
                {
                    if (money < 15.99)
                        Console.WriteLine("Too Expensive");
                    else if (money - 15.99 == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        money -= 15.99;
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    if (money < 19.99)
                        Console.WriteLine("Too Expensive");
                    else if (money - 19.99 == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        money -= 19.99;
                    }
                }
                else if (command == "Honored 2")
                {
                    if (money < 59.99)
                        Console.WriteLine("Too Expensive");
                    else if (money - 59.99 == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        money -= 59.99;
                    }
                }
                else if (command == "RoverWatch")
                {
                    if (money < 29.99)
                        Console.WriteLine("Too Expensive");
                    else if (money - 29.99 == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        money -= 29.99;
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    if (money < 39.99)
                        Console.WriteLine("Too Expensive");
                    else if (money - 39.99 == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                        money -= 39.99;
                    }
                }
                else
                    Console.WriteLine("Not Found");
            }
        }
    }
}
