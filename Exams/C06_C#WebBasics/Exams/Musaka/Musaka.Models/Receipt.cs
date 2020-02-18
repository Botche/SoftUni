using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musaka.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new List<Order>();
        }

        public string Id { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; }

        [Required]
        public string CashierId { get; set; }
        public User Cashier { get; set; }

        public IEnumerable<Order> Orders { get; set; }

    }
}
