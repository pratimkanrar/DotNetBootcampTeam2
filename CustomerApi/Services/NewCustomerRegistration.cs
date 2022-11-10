using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Entities;
using CustomerApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;
using CustomerApi.Interfaces;

namespace CustomerApi.Services
{
    public class NewCustomerRegistrationService : INewCustomerRegistration
    {
        private readonly CustomerDBContext context;
        public NewCustomerRegistrationService()
        {
            this.context = new CustomerDBContext();
        }
        public bool Register(Customer customer)
        {
            Customer IsPresent = context.Customers.SingleOrDefault(o => o.Username == customer.Username);
            if (IsPresent == null)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}