using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Entities;
using CustomerApi.Interfaces;
using CustomerApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Data.SqlClient;


namespace CustomerApi.Services
{
    public class CustomerChangePasswordService : ICustomerChangePasswordInterface
    {
        private readonly CustomerDBContext context;
        public CustomerChangePasswordService()
        {
            this.context = new CustomerDBContext();
        }

       
   
        public string ChangePassword(string Email, string OldPassword, string NewPassword)
        {
            Customer cust = context.Customers.SingleOrDefault(i => i.Email == Email);
            if (cust == null)
            {
                return "failed to change password";
            }
            if (cust.Password == OldPassword) {
                cust.Password = NewPassword;
                //context.Customers.Add(customer);
                context.SaveChanges();
                return "password changed successfully";
            }
            return "failed to change password";

        }
    }
}