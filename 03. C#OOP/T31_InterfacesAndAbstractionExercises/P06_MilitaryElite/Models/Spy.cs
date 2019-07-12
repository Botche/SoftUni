using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Spy : ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CodeNumber = codeNumber;
        }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int CodeNumber { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} ");
            sb.AppendLine($"Code Number: {CodeNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
