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
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService service;
        public PaymentController()
        {
            this.service = new PaymentService();
        }
        [Route("payments")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var payments = this.service.GetAll();
            return StatusCode(200, payments);
        }
        [Route("payments")]
        [HttpPut]
        public IActionResult Edit(Payment payment)
        {
            service.Edit(payment);
            return Ok(payment);
        }
    }
}