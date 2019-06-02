using System;
using System.IO;

namespace _02._LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader=new StreamReader("Input.txt"))
            {
                string line = reader.ReadLine();

                using (var writer =new StreamWriter("Output.txt"))
                {
                    int counter = 1;
                    while (line!=null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
