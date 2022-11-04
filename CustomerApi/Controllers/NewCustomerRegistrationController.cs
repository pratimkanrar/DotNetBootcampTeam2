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
    public class NewCustomerRegistrationController : ControllerBase
    {
        private readonly NewCustomerRegistrationService service;
        public NewCustomerRegistrationController()
        {
            this.service = new NewCustomerRegistrationService();
        }
        [Route("register")]
        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            service.Register(customer);
            return StatusCode(200, "New User Registered Successfully");
        }
    }
}