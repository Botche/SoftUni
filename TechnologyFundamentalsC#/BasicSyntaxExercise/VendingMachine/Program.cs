using System;

namespace vendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            double money = 0, sum = 0;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "Start")
                {
                    while (true)
                    {
                        command = Console.ReadLine();
                        if (command == "End")
                            break;
                        if (command == "Coke")
                        {
                            if (sum - 1 < 0)
                                Console.WriteLine("Sorry, not enough money");
                            else
                            {
                                Console.WriteLine($"Purchased {command.ToLower()}");
                                sum -= 1;
                            }
                        }
                        else if (command == "Nuts")
                        {
                            if (sum - 2 < 0)
                                Console.WriteLine("Sorry, not enough money");
                            else
                            {
                                Console.WriteLine($"Purchased {command.ToLower()}");
                                sum -= 2;
                            }
                        }
                        else if (command == "Water")
                        {
                            if (sum - 0.7 < 0)
                                Console.WriteLine("Sorry, not enough money");
                            else
                            {
                                Console.WriteLine($"Purchased {command.ToLower()}");
                                sum -= 0.7;
                            }
                        }
                        else if (command == "Crisps")
                        {
                            if (sum - 1.5 < 0)
                                Console.WriteLine("Sorry, not enough money");
                            else
                            {
                                Console.WriteLine($"Purchased {command.ToLower()}");
                                sum -= 1.5;
                            }
                        }
                        else if (command == "Soda")
                        {
                            if (sum - 0.8 < 0)
                                Console.WriteLine("Sorry, not enough money");
                            else
                            {
                                Console.WriteLine($"Purchased {command.ToLower()}");
                                sum -= 0.8;
                            }
                        }
                        else
                            Console.WriteLine("Invalid product");
                    }
                    Console.WriteLine($"Change: {sum:F2}");
                    break;
                }
                else
                {
                    money = double.Parse(command);
                    switch (money)
                    {
                        case 0.1:
                            sum += 0.1;
                            break;
                        case 0.2:
                            sum += 0.2;
                            break;
                        case 0.5:
                            sum += 0.5;
                            break;
                        case 1:
                            sum += 1;
                            break;
                        case 2:
                            sum += 2;
                            break;
                        default:
                            Console.WriteLine($"Cannot accept {money:f2}");
                            break;
                    }
                }
            }
        }
    }
}
