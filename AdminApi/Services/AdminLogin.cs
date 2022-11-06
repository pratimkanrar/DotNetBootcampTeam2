using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Entities;
//using AdminApi.Interfaces;
using AdminApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;
using AdminApi.Interfaces;
using Microsoft.Data.SqlClient;

namespace AdminApi.Services
{
    public class AdminLoginService : IAdminLoginInterface
    {
        private readonly AdminDBContext context;
        public AdminLoginService()
        {
            this.context = new AdminDBContext();
        }

       
        public bool Login(string Username,string Password)
        {
            Admin cust = context.Admin.SingleOrDefault(i => i.Username == Username);
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

     
    }
}