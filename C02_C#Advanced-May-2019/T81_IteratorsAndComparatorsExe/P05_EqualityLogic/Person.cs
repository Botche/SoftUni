using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic
{
    class Person:IComparable<Person>
    {
        private SortedSet<Person> sorted;
        private HashSet<Person> hash;

        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);

            if (result==0)
            {
                return Age.CompareTo(other.Age);
            }

            return result;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Name == ((Person)obj).Name && Age == ((Person)obj).Age;
        }
    }
}
