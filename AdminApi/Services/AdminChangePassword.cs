using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Entities;
using AdminApi.Interfaces;
using AdminApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Data.SqlClient;
using BankApi.Database;
using CustomerApi.Database;

namespace AdminApi.Services
{
    public class AdminChangePasswordService : IAdminChangePasswordInterface
    {
        private readonly AdminDBContext context;
        private readonly BankDBContext bankContext;
        private readonly CustomerDBContext customerContext;
        public AdminChangePasswordService()
        {
            this.context = new AdminDBContext();
            this.bankContext = new BankDBContext();
        }

       
   
        public string ChangePassword(string Email, string OldPassword, string NewPassword)
        {
            Admin cust = context.Admin.SingleOrDefault(i => i.Email == Email);
            if (cust == null)
            {
                return "failed to change password";
            }
            if (cust.Password == OldPassword) {
                cust.Password = NewPassword;
              
                context.SaveChanges();
                return "password changed successfully";
            }
            return "failed to change password";
        


        }
    }
}