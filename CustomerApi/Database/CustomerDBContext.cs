using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerApi.Entities;

namespace CustomerApi.Database
{
    public class CustomerDBContext : DbContext
    {
        //Entity set
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //define connection string.
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=test;Trusted_Connection=True;");
        }
    }
}