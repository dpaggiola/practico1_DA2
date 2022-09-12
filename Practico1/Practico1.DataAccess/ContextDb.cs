using System;
using Microsoft.EntityFrameworkCore;
using Practico1.Domain;

namespace Practico1.DataAccess
{
    public class ContextDb : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public ContextDb(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}

