using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using OnlineShoppingCoreApi.Models.Repository;
using OnlineShoppingCoreApi.Models;

namespace OnlineShoppingCoreApi.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IDataAccessRepository<Payment> _dataRepository;

        public PaymentController(IDataAccessRepository<Payment> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetPayment")]
        public IActionResult GetPayment()
        {
            IEnumerable<Payment> payments = _dataRepository.GetAll();
            return Ok(payments);
        }


        [HttpGet(Name = "GetPayment")]
        [Route("GetPaymentById/{PaymentId}")]
        public IActionResult GetPaymentById(long PaymentId)
        {
            Payment payment = _dataRepository.Get(PaymentId);
            if (payment == null)
            {
                return NotFound("payment record not found !!!");
            }
            //return Ok(_dataRepository.Get(PaymentId));
            return Ok(payment);
        }


        [HttpPost]
        [Route("InsertPayment")]
        public IActionResult PostPayment([FromBody] Payment payment)
        {
            if (payment == null)
            {
                return BadRequest("payment is null !!!");
            }
            _dataRepository.Add(payment);
            return CreatedAtRoute("GetPayment", new { Id = payment.PaymentID }, payment);
        }

        [HttpPut]
        [Route("Updatepayment/{PaymentId}")]
        public IActionResult Putpayment(long PaymentId, [FromBody] Payment payment)
        {
            if (payment == null)
            {
                return BadRequest("purchase is null !!!");
            }
            Payment paymentToUpdate = _dataRepository.Get(PaymentId);
            if (paymentToUpdate == null)
            {
                return NotFound("payment record not found !!!");
            }
            _dataRepository.Update(paymentToUpdate, payment);
            return CreatedAtRoute("GetPayment", new { Id = payment.PaymentID }, payment);
        }

        [HttpDelete]
        [Route("DeletePayment/{PaymentId}")]
        public IActionResult DeletePayment(long PaymentId)
        {
            Payment payment = _dataRepository.Get(PaymentId);
            if (payment == null)
            {
                return NotFound("payment record not found !!!");
            }
            _dataRepository.Delete(payment);
            return GetPayment();
        }
    }

}
