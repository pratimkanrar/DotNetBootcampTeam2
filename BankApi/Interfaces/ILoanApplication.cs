using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
namespace BankApi.Interfaces
{
    public interface ILoanApplication
    {
        List<LoanApplications> GetAll();
        LoanApplications GetByCustId(int custid);
        void Add(LoanApplications application);
        void Edit(LoanApplications application);
    }
}