﻿using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Service;
using dotnetapp.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        
       [Authorize(Roles="Admin,Student")]

        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPayments();
            return Ok(payments);
        }

        [Authorize(Roles="Admin,Student")]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

       [Authorize(Roles="Student")]

        [HttpPost]
        public async Task<IActionResult> CreatePayment(Payment payment)
        {
            await _paymentService.CreatePayment(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentID }, payment);
        }
    }
}