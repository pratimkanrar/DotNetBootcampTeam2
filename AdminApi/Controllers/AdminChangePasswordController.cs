using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Entities;
using AdminApi.Services;
namespace AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminChangePasswordController : ControllerBase
    {
        private readonly AdminChangePasswordService service;
        public AdminChangePasswordController()
        {
            this.service = new AdminChangePasswordService();
        }
        [Route("changePassword")]
        [HttpPost]
        public IActionResult ChangePassword(string email,string oldpassword,string newpassword)
        {
            string res=service.ChangePassword(email,oldpassword,newpassword);
            return StatusCode(200, res);
        }
    }
}