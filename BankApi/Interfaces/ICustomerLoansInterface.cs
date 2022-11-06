using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
namespace BankApi.Interfaces
{
    public interface ICustomerLoansInterface
    {
        public List<LoanApplications> GetCustomerLoans(int custId);
    }
}