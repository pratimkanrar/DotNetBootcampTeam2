using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
using BankApi.Interfaces;
using BankApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Data.SqlClient;
using BankApi.Migrations;
using CustomerApi.Database;

namespace BankApi.Services
{
    public class CustomerLoansService : ICustomerLoansInterface
    {
        private readonly BankDBContext context;
        private readonly CustomerDBContext customerContext;


        public CustomerLoansService()
        {
            this.context = new BankDBContext();
         
        }
        public List<LoanApplications> GetCustomerLoans(int custId) {
            var res = (from p in context.LoanApplications
                     where p.CustId == custId
                     select p).ToList();
            /*var s = from d in
                   customerContext.Customers
                    where res.Select(x => x.CustId).Contains(d.Id)
                    select d;*/
                 
            return res;
           
        }
           


        }
    }
