using CustomerApi.Database;
using CustomerApi.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CustomerApi.Interfaces;

namespace CustomerApi.Services
{
    public class LoginService : ILoginService
    {
        private IConfiguration _config;
        private readonly CustomerDBContext context;
        public LoginService(IConfiguration config)
        {
            _config = config;
            context = new CustomerDBContext();
        }
        public string Generate(Customer user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Customer Authenticate(CustomerLogin Customer)
        {
            var user = this.context.Customers.SingleOrDefault(o => o.Username == Customer.Username && o.Password == Customer.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public void ChangePassword(CustomerLogin Customer)
        {
            var user = this.context.Customers.SingleOrDefault(o => o.Username == Customer.Username);
            if (user != null)
            {
                user.Password = Customer.Password;
                this.context.Customers.Update(user);
            }
        }
    }
}
