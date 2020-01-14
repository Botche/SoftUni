using System;
using System.Linq;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = null;
            CustomStack<string> customStack = new CustomStack<string>();
            
            while ((command=Console.ReadLine())!="END")
            {
                try
                {
                    if (command.Contains("Push"))
                    {
                        command = command.Replace("Push ", "");
                        string[] items = command
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                        customStack.Push(items);
                    }
                    else if (command == "Pop")
                    {
                        customStack.Pop();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
