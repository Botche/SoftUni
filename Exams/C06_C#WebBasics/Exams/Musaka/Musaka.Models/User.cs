using System;
using System.Collections.Generic;
using System.Text;
using SIS.MvcFramework;

namespace Musaka.Models
{
    public class User:IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new List<Order>();
            this.Receipts = new List<Receipt>();
        }

        public IEnumerable<Order> Orders { get; set; }

        public IEnumerable<Receipt> Receipts { get; set; }
    }
}
