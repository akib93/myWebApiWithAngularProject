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
    [RoutePrefix("api/CancelOrder")]

    public class CancelOrderController : ApiController
    {
        private IDataAccessRepository<CancelOrder, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 
        public CancelOrderController(IDataAccessRepository<CancelOrder, int> r)
        {
            _repository = r;
        }


        [HttpGet]
        [Route("GetCancelOrder", Name = "GetCancelOrder")]
        public IEnumerable<CancelOrder> GetCancelOrder()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetCancelOrderById/{cancelOrderId}")]
        public IHttpActionResult GetCancelOrderById(int cancelOrderId)
        {
            return Ok(_repository.Get(cancelOrderId));
        }


        [HttpPost]
        [Route("InsertCancelOrder")]
        public IHttpActionResult PostCancelOrder(CancelOrder cancelOrder)
        {
            _repository.Post(cancelOrder);
            return Ok(cancelOrder);
        }

        [HttpPut]
        [Route("UpdateCancelOrder/{cancelOrderId}")]
        public IHttpActionResult PutCancelOrder(int cancelOrderId, CancelOrder cancelOrder)
        {
            _repository.Put(cancelOrderId, cancelOrder);
            return CreatedAtRoute("GetCancelOrder", new { Id = cancelOrder.CancelOrderID }, cancelOrderId);
        }

        [HttpDelete]
        [Route("DeleteCancelOrder/{cancelOrderId}")]
        public IHttpActionResult DeleteCancelOrder(int cancelOrderId, CancelOrder cancelOrder)
        {
            _repository.Delete(cancelOrderId);
            return CreatedAtRoute("GetCancelOrder", new { Id = cancelOrder.CancelOrderID }, cancelOrder);
        }
    }
}
