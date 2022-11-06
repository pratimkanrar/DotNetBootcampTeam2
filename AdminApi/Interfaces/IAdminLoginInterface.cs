using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Entities;
namespace AdminApi.Interfaces
{
    public interface IAdminLoginInterface
    {
        public bool Login(string Username,string Password);
    }
}