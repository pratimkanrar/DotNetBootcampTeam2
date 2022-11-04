using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankApi.Entities;
namespace BankApi.Database
{
    public class BankDBContext : DbContext
    {
        //Entity set
        public DbSet<Payment> Payments { get; set; }
        public DbSet<LoanApplications> LoanApplications { get; set; }
        public DbSet<LoanRate> LoanRates { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //define connection string.
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=test;Trusted_Connection=True;");
        }
    }
}