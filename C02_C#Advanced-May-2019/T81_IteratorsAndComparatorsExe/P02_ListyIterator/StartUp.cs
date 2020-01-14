using System;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;
            string command = null;

            while ((command= Console.ReadLine())!="END")
            {
                try
                {
                    if (command.Contains("Create"))
                    {
                        string[] items = command
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1)
                            .ToArray();

                        listyIterator = new ListyIterator<string>(items.ToList());
                    }
                    else if (command == "Print")
                    {
                        listyIterator.Print();
                    }
                    else if(command=="HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    else if(command=="Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if(command=="PrintAll")
                    {
                        foreach (var item in listyIterator)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
