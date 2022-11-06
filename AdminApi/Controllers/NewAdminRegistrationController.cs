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
    public class NewAdminRegistrationController : ControllerBase
    {
        private readonly NewAdminRegistrationService service;
        public NewAdminRegistrationController()
        {
            this.service = new NewAdminRegistrationService();
        }
        [Route("register")]
        [HttpPost]
        public IActionResult Register(Admin Admin)
        {
            service.Register(Admin);
            return StatusCode(200, "New User Registered Successfully");
        }
    }
}