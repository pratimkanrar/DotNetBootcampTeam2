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
    public class ReceivePaymentController : ControllerBase
    {
        private readonly ReceivePaymentService service;
        public ReceivePaymentController()
        {
            this.service = new ReceivePaymentService();
        }
        [HttpGet("getAllPayments")]
        public IActionResult GetAllPayments()
        {
            List<Payment> res= this.service.GetAllPayments();
            return StatusCode(200, res);
        }
        [HttpGet("getPaymentsById")]
        public IActionResult GetPaymentsById(int CustomerId)
        {
            List<Payment> res = this.service.GetPaymentByCustId(CustomerId);
            return StatusCode(200, res);
        }
        [Route("addPayment")]
        [HttpPost]
        public IActionResult AddPayment(Payment payment)
        {
             this.service.AddPayment(payment);
            return StatusCode(200, "Payment added");
        }
        [HttpPost("editPayment")]
        public IActionResult EditPayment(Payment payment)
        {
            this.service.EditPayment(payment);
            return StatusCode(200, "Payment updated");
        }
        [HttpDelete("deletePayment")]
        public IActionResult DeletePayment(int receiptId)
        {
            this.service.DeletePayment(receiptId);
            return StatusCode(200, "Payment deleted");
        }

    }
}