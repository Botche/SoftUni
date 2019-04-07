using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<Book> books { get; set; }

        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=BooksDb;Integrated Security=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
