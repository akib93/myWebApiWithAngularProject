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
    [Route("api/Shippment")]
    [ApiController]
    public class ShippmentController : ControllerBase
    {

        private readonly IDataAccessRepository<Shippment> _dataRepository;

        public ShippmentController(IDataAccessRepository<Shippment> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetShippment")]
        public IActionResult GetPayment()
        {
            IEnumerable<Shippment> shippments = _dataRepository.GetAll();
            return Ok(shippments);
        }


        [HttpGet(Name = "GetShippment")]
        [Route("GetShippmentById/{ShippmentId}")]
        public IActionResult GetShippmentById(long ShippmentId)
        {
            Shippment shippment = _dataRepository.Get(ShippmentId);
            if (shippment == null)
            {
                return NotFound("shippment record not found !!!");
            }
            return Ok(shippment);
        }


        [HttpPost]
        [Route("Insertshippment")]
        public IActionResult Postshippment([FromBody] Shippment shippment)
        {
            if (shippment == null)
            {
                return BadRequest("shippment is null !!!");
            }
            _dataRepository.Add(shippment);
            return CreatedAtRoute("GetShippment", new { Id = shippment.ShippmentID }, shippment);
        }


        [HttpPut]
        [Route("UpdateShippment/{ShippmentId}")]
        public IActionResult PutShippment(long ShippmentId, [FromBody] Shippment shippment)
        {
            if (shippment == null)
            {
                return BadRequest("Shippment is null !!!");
            }
            Shippment ShippmentToUpdate = _dataRepository.Get(ShippmentId);
            if (ShippmentToUpdate == null)
            {
                return NotFound("shippment record not found !!!");
            }
            _dataRepository.Update(ShippmentToUpdate, shippment);
            return CreatedAtRoute("GetShippment", new { Id = shippment.ShippmentID }, shippment);

            //_dataRepository.Update(ShippmentId, shippment);
            //return CreatedAtRoute("GetShippment", new { Id = shippment.ShippmentID }, shippment);
        }


        [HttpDelete]
        [Route("DeleteShippemt/{ShippmentId}")]
        public IActionResult DeleteShippment(long ShippmentId)
        {
            Shippment shippment = _dataRepository.Get(ShippmentId);
            if (shippment == null)
            {
                return NotFound("Shippment record not found !!!");
            }
            _dataRepository.Delete(shippment);
            return GetPayment();
        }
    }
}
