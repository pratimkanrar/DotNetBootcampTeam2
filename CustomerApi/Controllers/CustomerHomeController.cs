using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom.Compiler;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using CustomerApi.Services;
using CustomerApi.Entities;
using System.Linq.Expressions;
using System.Collections;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerHomeController : ControllerBase
    {
        private readonly CustomerHomeService service;
        public CustomerHomeController()
        {
            this.service = new CustomerHomeService();
        }
        [Authorize]
        [HttpGet]
        [Route("home")]
        public IActionResult CustomerHome()
        {
            var user = GetCurrentUser();
            if(user!=null)
            {
                Customer customer = this.service.GetCustomerDetails(user.Username, user.Email);
                if (customer != null)
                {
                    return Ok(customer);
                }
            }
            return BadRequest();
        }

        private Customer GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new Customer
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value
                };
            }
            return null;
        }
    }
}