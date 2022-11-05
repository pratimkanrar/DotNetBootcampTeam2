using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdminApi.Entities;
namespace AdminApi.Database
{
    public class AdminDBContext : DbContext
    {
        //Entity set
        public DbSet<Admin> Admin { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //define connection string.
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=test1;Trusted_Connection=True;");
        }
    }
}