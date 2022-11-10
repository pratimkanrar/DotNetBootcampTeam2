using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AdminApi.Services;
using AdminApi.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminLoginController : ControllerBase
    {
        private readonly LoginService service;
        public AdminLoginController(IConfiguration config)
        {
            this.service = new LoginService(config);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] AdminLogin admin)
        {
            var user = this.service.Authenticate(admin);
            if (user != null)
            {
                var token = this.service.Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("changepassword")]
        public IActionResult ChangePassword([FromBody] AdminLogin admin)
        {
            this.service.ChangePassword(admin);
            return Ok("Password Changed");
        }
    }
}