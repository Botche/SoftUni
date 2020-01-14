using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._ReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filters = new List<string>();

            string[] input = new string[3];
            CollectFilters(filters, input);

            UseTheFilters(filters, names);

            Console.WriteLine(string.Join(" ",names));
        }

        private static void UseTheFilters(List<string> filters, List<string> names)
        {
            foreach (var filter in filters)
            {
                string condition = filter.Split(";")[0];
                string parameter = "";
                int lengthParameter = 0;

                switch (condition)
                {
                    case "Starts with":
                        parameter= filter.Split(";")[1];
                        RemoveElementStartsWith(names, parameter);
                        break;
                    case "Ends with":
                        parameter = filter.Split(";")[1];
                        RemoveElementEndsWith(names, parameter);
                        break;
                    case "Length":
                        lengthParameter = int.Parse(filter.Split(";")[1]);
                        RemoveElementLength(names, lengthParameter);
                        break;
                    case "Contains":
                        parameter = filter.Split(";")[1];
                        RemoveElementContains(names, parameter);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void RemoveElementContains(List<string> names, string parameter)
        {
            for (int i = names.Count - 1; i >= 0; i--)
            {
                if (names[i].Contains(parameter))
                {
                    names.RemoveAt(i);
                }
            }
        }

        private static void RemoveElementLength(List<string> names, int parameter)
        {
            for (int i = names.Count - 1; i >= 0; i--)
            {
                if (names[i].Length==parameter)
                {
                    names.RemoveAt(i);
                }
            }
        }

        private static void RemoveElementEndsWith(List<string> names, string parameter)
        {
            for (int i = names.Count - 1; i >= 0; i--)
            {
                if (names[i].EndsWith(parameter))
                {
                    names.RemoveAt(i);
                }
            }
        }

        private static void RemoveElementStartsWith(List<string> names, string parameter)
        {
            for (int i = names.Count - 1; i >= 0; i--)
            {
                if (names[i].StartsWith(parameter))
                {
                    names.RemoveAt(i);
                }
            }
        }

        private static void CollectFilters(List<string> filters, string[] input)
        {
            while ((input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries))[0]
                != "Print")
            {
                string command = input[0];
                string condition = input[1];
                string conditionPara = input[2];

                AddOrRemoveFilter(filters, condition, conditionPara, command);
            }
        }

        private static void AddOrRemoveFilter(List<string> filters, string condition, string conditionPara, string command)
        {
            if (command == "Add filter")
            {
                filters.Add(condition + ";" + conditionPara);
            }
            else
            {
                filters.Remove(condition + ";" + conditionPara);
            }
        }
    }
}
