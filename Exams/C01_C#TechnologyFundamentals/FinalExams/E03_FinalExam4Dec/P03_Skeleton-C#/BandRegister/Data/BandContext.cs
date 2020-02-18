using BandRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandRegister.Data
{
    public class BandContext:DbContext
    {
        public DbSet<Band> bands { get; set; }

        private const string ConnectionStirng = @"Server=.\SQLEXPRESS;Database=BandsDb;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStirng);
        }
    }
}
