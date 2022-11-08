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
using static System.Net.Mime.MediaTypeNames;

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
        [Route("customerapplications")]
        [HttpGet]
        public IActionResult GetAll()
        {
            if (this.HttpContext.Request.Headers["Authorization"].ToString() == "")
            {
                return StatusCode(401, "Unauthorized");
            }
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
        [Route("customerapplications")]
        [HttpPut]
        public IActionResult Edit([FromBody] LoanApplications application)
        {
            if (this.HttpContext.Request.Headers["Authorization"].ToString() == "")
            {
                return StatusCode(401, "Unauthorized");
            }
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", this.HttpContext.Request.Headers["Authorization"].ToString());
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5248/AdminHome/home");
            var response = client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                this.service.Edit(application);
                return Ok(application);
            }
            return StatusCode(401, "Not Authorized");
        }
        [Route("customerapplications/{custid}")]
        [HttpGet]
        public IActionResult GetByCustId(int custid)
        {
            if (this.HttpContext.Request.Headers["Authorization"].ToString() == "")
            {
                return StatusCode(401, "Unauthorized");
            }
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", this.HttpContext.Request.Headers["Authorization"].ToString());
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5248/CustomerHome/home");
            var response = client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                return Ok(this.service.GetByCustId(custid));
            }
            return StatusCode(401, "Not Authorized");
        }
        [Route("customerapplications")]
        [HttpPost]
        public IActionResult ApplyforLoan([FromBody] LoanApplications application)
        {
            return Ok("hi");
            if (this.HttpContext.Request.Headers["Authorization"].ToString() == "")
            {
                return StatusCode(401, "Unauthorized");
            }
            application.IsApproved = 0;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", this.HttpContext.Request.Headers["Authorization"].ToString());
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5248/CustomerHome/home");
            var response = client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                this.service.Add(application);
                return Ok(application);
            }
            return StatusCode(401, "Not Authorized");
        }
    }
}