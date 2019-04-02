using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strs = Console.ReadLine()
                .Split()
                .ToList();
            string command = Console.ReadLine();
            while (command!="3:1")
            {
                string[] arrOfCom = command
                    .Split()
                    .ToArray();
                switch(arrOfCom[0])
                {
                    case "merge":
                        int startIndex = int.Parse(arrOfCom[1]);
                        if (startIndex < 0)
                            startIndex = 0;
                        int endIndex = int.Parse(arrOfCom[2]);
                        if (endIndex >= strs.Count)
                            endIndex = strs.Count - 1;
                        for (int i = 0; i < endIndex - startIndex; i++)
                        {
                            strs[startIndex] += strs[startIndex + 1];
                            strs.RemoveAt(startIndex + 1);
                        }
                        break;
                    case "divide":
                        int index = int.Parse(arrOfCom[1]);
                        int division = int.Parse(arrOfCom[2]);
                        string element = strs[index];
                        int brDivision = element.Length / division;
                        int multi = 0;
                        for (int i = 1; i <= division; i++)
                        {
                            if (i == division)
                                strs.Insert(index + i, element.Substring(brDivision * multi));
                            else
                            strs.Insert(index + i, element.Substring(brDivision * multi, brDivision));
                            
                            multi++;
                        }
                        strs.RemoveAt(index);
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",strs));
        }
    }
}
