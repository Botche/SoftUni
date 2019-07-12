using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral :Private, ILeutenantGeneral
    {
        private List<Private> privates;
        public LieutenantGeneral(string id, string firstName, string lastName,decimal salary)
            :base(id,firstName,lastName,salary)
        {
            privates = new List<Private>();
        }
        public IReadOnlyCollection<Private> Privates { get => privates; }

        public void AddPrivate(Private @private)
        {
            privates.Add(@private);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine("Privates:");
            foreach (var priv in Privates)
            {
                sb.AppendLine($"  {priv.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
