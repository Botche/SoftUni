using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Forum.Models;

namespace Forum.Data
{
    public class ForumDbContext : IdentityDbContext<ApplicationUser>
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=TopicsDb;Integrated Security=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
