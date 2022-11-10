using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
using BankApi.Services;
using static System.Net.Mime.MediaTypeNames;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanRateController : ControllerBase
    {
        private readonly LoanRateService service;
        public LoanRateController()
        {
            this.service = new LoanRateService();
        }
        [Route("loanrates")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var loanRates = this.service.GetAll();
            return StatusCode(200, loanRates);
        }
        [Route("loanrates")]
        [HttpPut]
        public IActionResult Edit([FromBody] LoanRate loanrate)
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
                this.service.Edit(loanrate);
                return Ok(loanrate);
            }
            return StatusCode(401, "Not Authorized");
        }
        [Route("loanrates")]
        [HttpPost]
        public IActionResult Add([FromBody] LoanRate loanrate)
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
                this.service.Add(loanrate);
                return Ok(loanrate);
            }
            return StatusCode(401, "Not Authorized");
        }
    }
}