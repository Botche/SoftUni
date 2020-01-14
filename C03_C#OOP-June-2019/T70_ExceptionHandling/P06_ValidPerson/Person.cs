using System;
using System.Collections.Generic;
using System.Text;

namespace P06_ValidPerson
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        "value",
                        "First name cannot be null or empty!");
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        "value",
                        "Last name cannot be null or empty!");
                }

                lastName = value;
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException(
                        "value",
                        "Age should be in the range [0...120].");
                }

                age = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"{firstName} {LastName} is {Age} years old.");

            return sb.ToString().TrimEnd();
        }
    }
}
