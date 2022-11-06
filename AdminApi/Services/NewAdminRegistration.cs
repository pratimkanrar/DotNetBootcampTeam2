using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Entities;
using AdminApi.Interfaces;
using AdminApi.Database;
using Microsoft.AspNetCore.Routing.Constraints;


namespace AdminApi.Services
{
    public class NewAdminRegistrationService : INewAdminRegistrationInterface
    {
        private readonly AdminDBContext context;
        public NewAdminRegistrationService()
        {
            this.context = new AdminDBContext();
        }
        public void Register(Admin admin)
        {
            context.Admin.Add(admin);
            context.SaveChanges();
        }
    }
}