using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using AdminApi.Services;
using AdminApi.Entities;
using System.Linq.Expressions;
using System.Collections;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminHomeController : ControllerBase
    {
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("home")]
        public IActionResult AdminHome()
        {
            var user = GetCurrentUser();
            return Ok("Hi " + user.Username);
        }

        private Admin GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new Admin
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Address = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.StreetAddress)?.Value,
                };
            }
            return null;
        }
    }
}