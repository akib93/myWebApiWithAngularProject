using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using OnlineShoppingMvcApi.Models;
using OnlineShoppingMvcApi.Models.Repository;
using System.Web.Http.Description;

namespace OnlineShoppingMvcApi.Controllers
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {
        private IDataAccessRepository<Payment, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public PaymentController(IDataAccessRepository<Payment, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetPayment", Name = "GetPayment")]
        public IEnumerable<Payment> GetPayment()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetPaymentId/{paymentId}")]
        public IHttpActionResult GetPaymentId(int paymentId)
        {
            return Ok(_repository.Get(paymentId));
        }

        [HttpPost]
        [Route("InsertPayment")]
        public IHttpActionResult PostItem(Payment payment)
        {
            _repository.Post(payment);
            return Ok(payment);
        }

        [HttpPut]
        [Route("UpdatePayment/{paymentId}")]
        public IHttpActionResult PutItem(int paymentId, Payment payment)
        {
            _repository.Put(paymentId, payment);
            return CreatedAtRoute("Get", new { Id = payment.PaymentID }, payment);
        }


        [HttpDelete]
        [Route("DeletePayment/{paymentId}")]
        public IHttpActionResult DeletePayment(int paymentId, Payment payment)
        {
            _repository.Delete(paymentId);
            return CreatedAtRoute("GetItem", new { Id = payment.PaymentID }, payment);
        }
    }
}
