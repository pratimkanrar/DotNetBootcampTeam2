﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
using BankApi.Interfaces;
using BankApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;

namespace BankApi.Services
{
    public class LoanApplicationsService : ILoanApplication
    {
        private readonly BankDBContext context;
        public LoanApplicationsService()
        {
            this.context = new BankDBContext();
        }
        public List<LoanApplications> GetAll()
        {
            return this.context.LoanApplications.ToList();
        }
        public void Edit(LoanApplications application)
        {
            this.context.LoanApplications.Update(application);
            this.context.SaveChanges();
        }
    }
}