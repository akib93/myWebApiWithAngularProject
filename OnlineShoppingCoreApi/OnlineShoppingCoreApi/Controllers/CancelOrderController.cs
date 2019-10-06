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
    [Route("api/cancelOrder")]
    [ApiController]
    public class CancelOrderController : ControllerBase
    {
        private readonly IDataAccessRepository<CancelOrder> _dataRepository;

        public CancelOrderController(IDataAccessRepository<CancelOrder> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        [Route("GetCancelOrder")]
        public IActionResult GetCancelOrder()
        {
            IEnumerable<CancelOrder> cancelOrders = _dataRepository.GetAll();
            return Ok(cancelOrders);
        }


        [HttpGet(Name = "GetCancelOrder")]
        [Route("GetCancelOrderById/{cancelOrderId}")]
        public IActionResult GetCancelOrderById(long cancelOrderId)
        {
            CancelOrder cancelOrder = _dataRepository.Get(cancelOrderId);
            if (cancelOrder == null)
            {
                return NotFound("Cancel Order record not found !!!");
            }
            return Ok(cancelOrder);
        }


        [HttpPost]
        [Route("InsertCancelOrder")]
        public IActionResult PostCancelOrder([FromBody] CancelOrder cancelOrder)
        {
            if (cancelOrder == null)
            {
                return BadRequest("Cancel Order is null !!!");
            }
            _dataRepository.Add(cancelOrder);
            return CreatedAtRoute("GetCancelOrder", new { Id = cancelOrder.CancelOrderID }, cancelOrder);
        }

        [HttpPut]
        [Route("UpdateCancelOrder/{cancelOrderId}")]
        public IActionResult PutBrand(long cancelOrderId, [FromBody]  CancelOrder cancelOrder)
        {
            if (cancelOrder == null)
            {
                return BadRequest("Cancel Order is null !!!");
            }
            CancelOrder cancelOrderToUpdate = _dataRepository.Get(cancelOrderId);
            if (cancelOrderToUpdate == null)
            {
                return NotFound("Cancel Order record not found !!!");
            }
            _dataRepository.Update(cancelOrderToUpdate, cancelOrder);
            return CreatedAtRoute("GetCancelOrder", new { Id = cancelOrder.CancelOrderID }, cancelOrder);
        }

        [HttpDelete]
        [Route("DeleteCancelOrder/{cancelOrderId}")]
        public IActionResult DeleteBrand(long cancelOrderId)
        {
            CancelOrder cancelOrder = _dataRepository.Get(cancelOrderId);
            if (cancelOrder == null)
            {
                return NotFound("Cancel Order record not found !!!");
            }
            _dataRepository.Delete(cancelOrder);
            return GetCancelOrder();
        }
    }
}