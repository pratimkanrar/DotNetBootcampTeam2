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
        [Route("getLoanRate")]
        [HttpPost]
        public IActionResult GetLoanrate()
        {
            List<LoanRate> res = this.service.GetLoanRate();
            return StatusCode(200, res);
        }
         [Route("editLoanRate")]
        [HttpPost]
        public IActionResult EditLoanrate(LoanRate loanRate)
        {
          this.service.EditLoanRate(loanRate);
            return StatusCode(200, true);
        }

    }
}