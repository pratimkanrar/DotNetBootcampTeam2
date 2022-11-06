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
    public class LoanApplicationController : ControllerBase
    {
        private readonly LoanApplicationService service;
        public LoanApplicationController()
        {
            this.service = new LoanApplicationService();
        }
        [Route("loanapplication")]
        [HttpPost]
        public IActionResult ApplyLoan(LoanApplications application)
        {
             this.service.ApplyLoan(application);
            return StatusCode(200, true);
        }
    }
}