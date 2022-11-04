using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Entities;
//using CustomerApi.Interfaces;
using CustomerApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;
using CustomerApi.Interfaces;

namespace CustomerApi.Services
{
    public class NewCustomerRegistrationService : INewCustomerRegistrationInterface
    {
        private readonly CustomerDBContext context;
        public NewCustomerRegistrationService()
        {
            this.context = new CustomerDBContext();
        }
        public void Register(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}