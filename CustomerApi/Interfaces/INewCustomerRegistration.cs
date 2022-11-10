using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Entities;
namespace CustomerApi.Interfaces
{
    public interface INewCustomerRegistration
    {
        public bool Register(Customer customer);
    }
}