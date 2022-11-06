using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
namespace BankApi.Interfaces
{
    public interface ILoanRateInterface
    {
        public List<LoanRate> GetLoanRate();
        public void EditLoanRate(LoanRate loanRate);
    }
}