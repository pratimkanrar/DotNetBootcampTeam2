using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Entities;
//using CustomerApi.Interfaces;
using CustomerApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;
using CustomerApi.Interfaces;
using Microsoft.Data.SqlClient;

namespace CustomerApi.Services
{
    public class CustomerLoginService : ICustomerLoginInterface
    {
        private readonly CustomerDBContext context;
        public CustomerLoginService()
        {
            this.context = new CustomerDBContext();
        }

       
        public bool Login(string Email,string Password)
        {
            Customer cust = context.Customers.SingleOrDefault(i => i.Email == Email);
        
            if (cust == null)
            {
                return false;
            }
            if(cust.Password == Password)
            {
                return true;
            }
            return false;
         
        }

        public Customer GetCustomerById(string email)
        {
            Customer customer=context.Customers.SingleOrDefault(i=>i.Email == email );
            return customer;
        }


    }
}