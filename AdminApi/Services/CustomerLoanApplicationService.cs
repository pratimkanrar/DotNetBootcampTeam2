using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Entities;
//using AdminApi.Interfaces;
using AdminApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;
using AdminApi.Interfaces;
using Microsoft.Data.SqlClient;
using BankApi.Database;
using CustomerApi.Database;
using Microsoft.AspNetCore.Authentication;

namespace AdminApi.Services
{
    public class CustomerLoanApplicationService : ICustomerLoanApplicationInterface
    {
        private readonly AdminDBContext context;
        private readonly BankDBContext bankContext;
        private readonly CustomerDBContext customerContext;


        public CustomerLoanApplicationService()
        {
            this.context = new AdminDBContext();
            this.bankContext = new BankDBContext();
            this.customerContext= new CustomerDBContext();
        }


        public IEnumerable<CustomerLoanApplications> getLoanApplications()
        {

             var d = (from c in customerContext.Customers
                      join b in bankContext.LoanApplications
                            on c.Id equals b.CustId
                      select new CustomerLoanApplications()
                      {
                          Id = b.Id,
                          LoanType = b.LoanType,
                          LoanAmount = b.LoanAmount,
                          CustomerName = c.Username,
                          MonthlyIncome = c.MonthlyIncome,
                          Gender = c.Gender,
                          Dob = c.Dob,
                          Address = c.Address,
                          Number = c.Number,
                          Email = c.Email,
                          IsApproved = b.IsApproved

                      }).ToList();
        

            return d;

        }


    }
}