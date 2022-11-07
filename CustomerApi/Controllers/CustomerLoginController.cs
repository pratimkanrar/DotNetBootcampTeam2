using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using CustomerApi.Services;
using CustomerApi.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerLoginController : ControllerBase
    {
        private readonly LoginService service;
        public CustomerLoginController(IConfiguration config)
        {
            this.service = new LoginService(config);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login(CustomerLogin Customer)
        {
            var user = this.service.Authenticate(Customer);
            if (user != null)
            {
                var token = this.service.Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }
        [Authorize]
        [HttpPut]
        [Route("changepassword")]
        public IActionResult ChangePassword(CustomerLogin Customer)
        {
            this.service.ChangePassword(Customer);
            return Ok("Password Changed");
        }
    }
}