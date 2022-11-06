using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BankApi.Entities;

namespace BankApi.Interfaces
{
    public interface IReceivePaymentInterface
    {

        public List<Payment> GetAllPayments();
        public void AddPayment(Payment payment);
        public void EditPayment(Payment payment);
        public void DeletePayment(int ReceiptId);
        public List<Payment> GetPaymentByCustId(int custId);

    }
}