using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AdminApi.Services;

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
        public IActionResult Login(string username, string password)
        {
            var user = this.service.Authenticate(username, password);
            if (user != null)
            {
                var token = this.service.Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }
    }
}