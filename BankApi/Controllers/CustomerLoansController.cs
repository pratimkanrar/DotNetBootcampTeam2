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
    public class CustomerLoansController : ControllerBase
    {
        private readonly CustomerLoansService service;
        public CustomerLoansController()
        {
            this.service = new CustomerLoansService();
        }
        [Route("myloans")]
        [HttpGet]
        public IActionResult GetLoans(int CustId)
        {
             List<LoanApplications> res=this.service.GetCustomerLoans(CustId);
            return StatusCode(200, res);
        }
    }
}