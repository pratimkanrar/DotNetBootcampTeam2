using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApi.Entities;
using AdminApi.Services;
namespace AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLoanApplicationController : ControllerBase
    {
        private readonly CustomerLoanApplicationService service;
        public CustomerLoanApplicationController()
        {
            this.service = new CustomerLoanApplicationService();
        }
        [Route("getLoanApplications")]
        [HttpPost]
        public IActionResult getLoanApplications()
        {
            IEnumerable<CustomerLoanApplications> res=service.getLoanApplications();
            return StatusCode(200, res);
        }
    }
}