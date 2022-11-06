using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
using BankApi.Services;

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
        public IActionResult Edit(LoanRate loanrate)
        {
            service.Edit(loanrate);
            return Ok(loanrate);
        }
    }
}