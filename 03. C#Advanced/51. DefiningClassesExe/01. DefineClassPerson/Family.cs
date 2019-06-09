using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> people = new List<Person>();
        List<Person> People { get; set; }
        public void AddMember(Person member)
        {
            people.Add(member);
        }
        public Person GetOldestMember()
        {
            Person oldestPerson = people.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;
        }

        public void PrintOlderThan30()
        {
            var sortedFamily = people
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();
            foreach (var member in sortedFamily)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
