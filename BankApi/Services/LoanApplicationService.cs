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


namespace BankApi.Services
{
    public class LoanApplicationService : ILoanApplicationInterface
    {
        private readonly BankDBContext context;
     



        public LoanApplicationService()
        {
            this.context = new BankDBContext();
         
        }
        public void ApplyLoan(LoanApplications application) {
            context.LoanApplications.Add(application);
            context.SaveChanges();
           
        }
           


        }
    }
