using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
using BankApi.Interfaces;
using BankApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;

namespace BankApi.Services
{
    public class LoanRateService : ILoanRate
    {
        private readonly BankDBContext context;
        public LoanRateService()
        {
            this.context = new BankDBContext();
        }
        public List<LoanRate> GetAll()
        {
            return this.context.LoanRates.ToList();
        }
        public void Edit(LoanRate loanrate)
        {
            this.context.LoanRates.Update(loanrate);
            this.context.SaveChanges();
        }
    }
}