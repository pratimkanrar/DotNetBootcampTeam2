using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Entities;
using CustomerApi.Services;
namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerChangePasswordController : ControllerBase
    {
        private readonly CustomerChangePasswordService service;
        public CustomerChangePasswordController()
        {
            this.service = new CustomerChangePasswordService();
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