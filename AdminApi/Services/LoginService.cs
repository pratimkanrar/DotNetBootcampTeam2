using AdminApi.Database;
using AdminApi.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AdminApi.Interfaces;

namespace AdminApi.Services
{
    public class LoginService : ILoginService
    {
        private IConfiguration _config;
        private readonly AdminDBContext context;
        public LoginService(IConfiguration config)
        {
            _config = config;
            context = new AdminDBContext();
        }
        public string Generate(Admin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.StreetAddress, user.Address)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Admin Authenticate(AdminLogin admin)
        {
            var user = this.context.Admin.FirstOrDefault(o => o.Username == admin.Username && o.Password == admin.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public void ChangePassword(AdminLogin admin)
        {
            var user = this.context.Admin.SingleOrDefault(o => o.Username == admin.Username);
            if (user != null)
            {
                user.Password = admin.Password;
                this.context.Admin.Update(user);
                this.context.SaveChanges();
            }
        }
    }
}
