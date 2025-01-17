﻿using Microsoft.AspNetCore.Http;
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
                var payments = this.service.GetAll();
                return StatusCode(200, payments);
            }
            return StatusCode(401, "Not Authorized");
        }
        [Route("payments")]
        [HttpPut]
        public IActionResult Edit([FromBody] Payment payment)
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
                service.Edit(payment);
                return Ok(payment);
            }
            return StatusCode(401, "Not Authorized");
        }
        [Route("payments")]
        [HttpPost]
        public IActionResult Add([FromBody] Payment payment)
        {
            if (this.HttpContext.Request.Headers["Authorization"].ToString() == "")
            {
                return StatusCode(401, "Unauthorized");
            }
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", this.HttpContext.Request.Headers["Authorization"].ToString());
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5248/api/CustomerHome/home");
            var response = client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                service.Add(payment);
                return Ok(payment);
            }
            return StatusCode(401, "Not Authorized");
        }
        [Route("payment/{id}")]
        [HttpGet]
        public IActionResult Search(int id)
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
                Payment payment = service.Get(id);
                return Ok(payment);
            }
            return StatusCode(401, "Not Authorized");
        }
        [Route("payments")]
        [HttpDelete]
        public IActionResult Delete([FromBody] Payment payment)
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
                service.Delete(payment);
                return Ok(payment);
            }
            return StatusCode(401, "Not Authorized");
        }
    }
}