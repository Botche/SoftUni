using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" -> ");
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                string company = input[0];
                string id = input[1];
                if (!companies.ContainsKey(company))
                    companies.Add(company, new List<string>());
                if (!companies[company].Contains(id))
                    companies[company].Add(id);

                input = Console.ReadLine()
                                .Split(" -> ");
            }
            var sortedCompanies = companies.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var company in sortedCompanies)
            {
                Console.WriteLine(company.Key);
                foreach (var id in company.Value)
                {
                    Console.WriteLine("-- " + id);
                }
            }
        }
    }
}
