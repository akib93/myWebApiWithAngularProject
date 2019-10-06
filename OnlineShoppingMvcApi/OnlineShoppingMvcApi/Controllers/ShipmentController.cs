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
    [RoutePrefix("api/Shipment")]
    public class ShipmentController : ApiController
    {
        private IDataAccessRepository<Shippment, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public ShipmentController(IDataAccessRepository<Shippment, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetShipment", Name = "GetShipment")]
        public IEnumerable<Shippment> GetShipment()
        {
            return _repository.Get().Where(s =>s.Status == "Pending");
        }

        [HttpGet]
        [Route("GetShipmentAll", Name = "GetShipmentAll")]
        public IEnumerable<Shippment> GetShipmentAll()
        {
            return _repository.Get();
        }


        [HttpGet]
        [Route("GetShipmentById/{shipmentId}")]
        public IHttpActionResult GetPaymentId(int shipmentId)
        {
            return Ok(_repository.Get(shipmentId));
        }

        [HttpPost]
        [Route("InsertShipment")]
        public IHttpActionResult PostItem(Shippment shippment)
        {
            _repository.Post(shippment);
            return Ok(shippment);
        }

        [HttpPut]
        [Route("UpdateShipment/{shipmentId}")]
        public IHttpActionResult PutItem(int shipmentId, Shippment shippment)
        {
            _repository.Put(shipmentId, shippment);
            return CreatedAtRoute("Get", new { Id = shippment.ShippmentID }, shippment);
        }

        [HttpDelete]
        [Route("DeleteShipment/{shipmentId}")]
        public IHttpActionResult DeletePayment(int shipmentId, Shippment shippment)
        {
            _repository.Delete(shipmentId);
            return CreatedAtRoute("GetItem", new { Id = shippment.ShippmentID }, shippment);
        }
    }
}
