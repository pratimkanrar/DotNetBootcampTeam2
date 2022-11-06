using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Entities;
namespace AdminApi.Interfaces
{
    public interface INewAdminRegistrationInterface
    {
        public void Register(Admin customer);
    }
}