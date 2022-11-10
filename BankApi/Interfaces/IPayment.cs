using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
namespace BankApi.Interfaces
{
    public interface IPayment
    {
        List<Payment> GetAll();
        void Edit(Payment payment);
        void Add(Payment payment);
        Payment Get(int id);
        void Delete(Payment payment);
    }
}