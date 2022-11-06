using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Entities;
namespace AdminApi.Interfaces
{
    public interface IAdminChangePasswordInterface
    {
        public string ChangePassword(string Email,string OldPassword,string NewPassword);
    }
}