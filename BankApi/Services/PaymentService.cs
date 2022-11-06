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
    public class PaymentService : IPayment
    {
        private readonly BankDBContext context;
        public PaymentService()
        {
            this.context = new BankDBContext();
        }
        public List<Payment> GetAll()
        {
            return this.context.Payments.ToList();
        }
        public void Edit(Payment payment)
        {
            this.context.Payments.Update(payment);
            this.context.SaveChanges();
        }
    }
}