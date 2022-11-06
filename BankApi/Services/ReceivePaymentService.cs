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
    public class ReceivePaymentService : IReceivePaymentInterface
    {
        private readonly BankDBContext context;
        
    
        public ReceivePaymentService()
        {
            this.context = new BankDBContext();
         
        }

        public List<Payment> GetAllPayments()
        {
            return context.Payments.ToList();
        }
        public void AddPayment(Payment payment) {
            context.Payments.Add(payment);
            context.SaveChanges();

        }

        public void EditPayment(Payment payment)
        {
            context.Payments.Update(payment);
            context.SaveChanges();

        }

        public void DeletePayment(int ReceiptId)
        {
            Payment payment=context.Payments.SingleOrDefault(i => i.ReceiptId == ReceiptId);
            context.Payments.Remove(payment);
            context.SaveChanges();

        }
        public List<Payment> GetPaymentByCustId(int custId)
        {

         var d=(from p in context.Payments
               where p.CustId == custId
               select p).ToList();
            return d;
            
  

        }





    }
    }
