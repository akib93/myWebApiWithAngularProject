using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCoreApi.Models;
using OnlineShoppingCoreApi.Models.Repository;

namespace OnlineShoppingCoreApi.Controllers
{
    [Route("api/OrderDetail")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IDataAccessRepository<OrderDetail> _dataRepository;

        public OrderDetailController(IDataAccessRepository<OrderDetail> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetOrderDetail")]
        public IActionResult GetOrderDetail()
        {
            IEnumerable<OrderDetail> orderDetails = _dataRepository.GetAll();
            return Ok(orderDetails);
        }


        [HttpGet(Name = "GetGetOrderDetail")]
        [Route("GetOrderDetailById/{orderDetailId}")]
        public IActionResult GetOrderDetailById(long orderDetailId)
        {
            OrderDetail orderDetail = _dataRepository.Get(orderDetailId);
            if (orderDetail == null)
            {
                return NotFound("orderDetail record not found !!!");
            }
            return Ok(orderDetail);
        }


        [HttpPost]
        [Route("InsertOrderDetail")]
        public IActionResult PostOrderDetail([FromBody] OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                return BadRequest("OrderDetail is null !!!");
            }
            _dataRepository.Add(orderDetail);
            return CreatedAtRoute("GetGetOrderDetail", new { Id = orderDetail.OrderDetailID }, orderDetail);
        }

        [HttpPut]
        [Route("UpdateOrderDetail/{orderDetailId}")]
        public IActionResult PutOrderDetail(long orderDetailId, [FromBody] OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                return BadRequest("orderDetail is null !!!");
            }
            OrderDetail orderDetailToUpdate = _dataRepository.Get(orderDetailId);
            if (orderDetailToUpdate == null)
            {
                return NotFound("orderDetail record not found !!!");
            }
            _dataRepository.Update(orderDetailToUpdate, orderDetail);
            return CreatedAtRoute("GetGetOrderDetail", new { Id = orderDetail .OrderDetailID}, orderDetail);
        }

        [HttpDelete]
        [Route("DeleteOrderDetail/{orderDetailId}")]
        public IActionResult DeleteOrderDetail(long orderDetailId)
        {
            OrderDetail orderDetail = _dataRepository.Get(orderDetailId);
            if (orderDetail == null)
            {
                return NotFound("OrderDetail record not found !!!");
            }
            _dataRepository.Delete(orderDetail);
            return GetOrderDetail();
        }

    }
}