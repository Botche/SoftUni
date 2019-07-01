using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Dictionary<string, string> users = new Dictionary<string, string>();

            for (int i = 0; i < length; i++)
            {
                string[] userInfo = Console.ReadLine()
                    .Split();
                string user = userInfo[1];
                if(userInfo[0]=="register")
                {
                    string pass = userInfo[2];
                    if(users.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {pass}");
                    }
                    else
                    {
                        Console.WriteLine($"{user} registered {pass} successfully");
                        users[user] = pass;
                    }
                }
                else
                {
                    if (!users.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{user} unregistered successfully");
                        users.Remove(user);
                    }
                }
            }
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
