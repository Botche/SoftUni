using System;

namespace ticketCombination
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            for(var i='B';i<='L';i++)
            {
                if(i%2==0)
                    for(var j='f';j>='a';j--)
                    {
                        for (var k = 'A';k<='C';k++)
                        {
                            for(var m=1;m<=10;m++)
                            {
                                for (var a = 10; a >= 1; a--)
                                {
                                    counter++;
                                    if(counter==n)
                                    {
                                        Console.WriteLine($"Ticket combination: {i}{j}{k}{m}{a}");
                                        Console.WriteLine($"Prize: {i+j+k+m+a} lv.");
                                        return;
                                    }
                                }
                            }
                        }
                    }
            }
        }
    }
}
