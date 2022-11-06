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
    public class AdminLoginController : ControllerBase
    {
        private readonly AdminLoginService service;
        public AdminLoginController()
        {
            this.service = new AdminLoginService();
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(string Username,string Password)
        {
            bool res=service.Login(Username,Password);
            return StatusCode(200, res);
        }
    }
}