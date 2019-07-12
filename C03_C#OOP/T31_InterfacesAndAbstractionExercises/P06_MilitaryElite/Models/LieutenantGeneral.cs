using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : ILeutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName,decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Privates = new List<Private>();
        }

        public decimal Salary { get;}
        public string Id { get;}
        public string FirstName { get;}
        public string LastName { get;}
        public List<Private> Privates { get;}

        public void AddPrivate(Private priv)
        {
            Privates.Add(priv);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");

            sb.AppendLine("Privates:");
            foreach (var priv in Privates)
            {
                sb.AppendLine($"  {priv.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
