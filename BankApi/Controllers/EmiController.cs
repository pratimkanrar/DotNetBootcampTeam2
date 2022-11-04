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
    public class EmiController : ControllerBase
    {
        private readonly EmiService service;
        public EmiController()
        {
            this.service = new EmiService();
        }
        [Route("calculateemi")]
        [HttpPost]
        public IActionResult CalculateEmi(int loanamount, double interestrate, int tenure)
        {
            double emi = this.service.CalculateEmi(loanamount, interestrate, tenure);
            return StatusCode(200, emi);
        }
    }
}