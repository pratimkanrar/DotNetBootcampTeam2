using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Entities;
namespace CustomerApi.Interfaces
{
    public interface ICustomerLoginInterface
    {
        public bool Login(string Email,string Password);
        public Customer GetCustomerById(string email);
    }
}