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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerLoginService service;
        public CustomerController()
        {
            this.service = new CustomerLoginService();
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(string email,string password)
        {
            bool res=service.Login(email,password);
            return StatusCode(200, res);
        }

        [HttpGet("getByEmail")]
        public IActionResult GetCustomerById(string email)
        {
            Customer res = service.GetCustomerById(email);
            return StatusCode(200, res);
        }
    }
}