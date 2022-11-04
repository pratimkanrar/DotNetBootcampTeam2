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
    public class EmiService : IEmiInterface
    {
        private readonly BankDBContext context;
        public EmiService()
        {
            this.context = new BankDBContext();
        }
        public double CalculateEmi(int loanamount, double interestrate, int tenure)
        {
            if (interestrate > 1)
            {
                interestrate = interestrate / 100;
            }
           double Payment = (loanamount * Math.Pow((interestrate / 12) + 1,
                      (tenure)) * interestrate / 12) / (Math.Pow
                      (interestrate / 12 + 1, (tenure)) - 1);
            //double emi = (loanamount * (interestrate / 12)) * (Math.Pow(1 + (interestrate / 12), tenure)) / (Math.Pow(1 + (interestrate / 12), tenure) - 1);
            return Payment;        
        }
       
    }
}