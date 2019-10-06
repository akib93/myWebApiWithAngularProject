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
    [RoutePrefix("api/OrderDetail")]
    public class OrderDetailController : ApiController
    {
        private IDataAccessRepository<OrderDetail, int> _repository;


        //Inject the DataAccessReposity using Contruction Injection 
        public OrderDetailController(IDataAccessRepository<OrderDetail, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetOrderDetail", Name = "OrderDetail")]
        public IEnumerable<OrderDetail> GetItem()
        {
            return _repository.Get().Where(s =>s.Status=="Pending");
        }


        [HttpGet]
        [Route("GetOrderDetailAll", Name = "OrderDetailAll")]
        public IEnumerable<OrderDetail> GetItemAll()
        {
            return _repository.Get();
        }


        [HttpGet]
        [Route("GetOrderDetailById/{orderDetailId}")]
        public IHttpActionResult GetOrderDetailById(int orderDetailId)
        {
            return Ok(_repository.Get(orderDetailId));
        }


        [HttpPost]
        [Route("InsertOrderDetail")]
        public IHttpActionResult PostItem(OrderDetail orderDetail)
        {
            _repository.Post(orderDetail);
            return Ok(orderDetail);
        }

        [HttpPut]
        [Route("UpdateOrderDetail/{orderDetailId}")]
        public IHttpActionResult PutItem(int orderDetailId, OrderDetail orderDetail)
        {
            _repository.Put(orderDetailId, orderDetail);
            return CreatedAtRoute("OrderDetail", new { Id = orderDetail.OrderDetailID }, orderDetail);
        }

        [HttpDelete]
        [Route("DeleteOrderDetail/{orderDetailId}")]
        public IHttpActionResult DeleteItem(int orderDetailId, OrderDetail orderDetail)
        {
            _repository.Delete(orderDetailId);
            return CreatedAtRoute("OrderDetail", new { Id = orderDetail.OrderDetailID }, orderDetail);
        }

    }
}
