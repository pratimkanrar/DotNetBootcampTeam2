using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
using BankApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Json;
using System.Net.Http;
using System.Text.Json;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationsController : ControllerBase
    {
        private readonly LoanApplicationsService service;
        public LoanApplicationsController()
        {
            this.service = new LoanApplicationsService();
        }
        //[Authorize(Roles="Administrator")]
        [Route("customerapplications")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", this.HttpContext.Request.Headers["Authorization"].ToString());
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5248/AdminHome/home");
            var response = client.Send(request);
            if(response.IsSuccessStatusCode)
            {
                var applications = this.service.GetAll();
                return Ok(applications);
            }
            return StatusCode(401, "Not Authorized");
        }
        //[Authorize(Roles = "Administrator")]
        [Route("customerapplications")]
        [HttpPut]
        public IActionResult Edit(LoanApplications application)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", this.HttpContext.Request.Headers["Authorization"].ToString());
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5248/AdminHome/home");
            var response = client.Send(request);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                this.service.Edit(application);
                return Ok(application);
            }
            return StatusCode(401, "Not Authorized");
        }
    }
}