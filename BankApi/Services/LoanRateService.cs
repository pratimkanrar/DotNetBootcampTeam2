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
    public class LoanRateService : ILoanRateInterface
    {
        private readonly BankDBContext context;
        public LoanRateService()
        {
            this.context = new BankDBContext();
        }
       public List<LoanRate> GetLoanRate()
        {
          return context.LoanRates.ToList();
        }
        public void EditLoanRate(LoanRate loanRate)
        {
            context.LoanRates.Update(loanRate);
            context.SaveChanges();
        }
      

        
       
    }
}