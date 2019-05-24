using System;

namespace login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string correctPass = string.Empty;
            int br = 0;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                correctPass += username[i];
            }
            string pass = Console.ReadLine();
            while (true)
            {
                if (pass == correctPass)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    br++;
                    if (br == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }  
                    Console.WriteLine("Incorrect password. Try again.");
                    pass = Console.ReadLine();
                }
            }
        }
    }
}
