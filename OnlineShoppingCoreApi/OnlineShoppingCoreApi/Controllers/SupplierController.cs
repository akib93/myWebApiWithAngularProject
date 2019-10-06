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
    [Route("api/Supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IDataAccessRepository<Supplier> _dataRepository;

        public SupplierController(IDataAccessRepository<Supplier> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        [Route("GetSupplier")]
        public IActionResult GetSupplier()
        {
            IEnumerable<Supplier> suppliers = _dataRepository.GetAll();
            return Ok(suppliers);
        }


        [HttpGet(Name = "GetSupplier")]
        [Route("GetSupplierById/{supplierId}")]
        public IActionResult GetSupplierById(long supplierId)
        {
            Supplier supplier = _dataRepository.Get(supplierId);
            if (supplier == null)
            {
                return NotFound("Supplier record not found !!!");
            }
            return Ok(supplier);
        }


        [HttpPost]
        [Route("InsertSupplier")]
        public IActionResult PostSupplier([FromBody] Supplier supplier)
        {
            if (supplier == null)
            {
                return BadRequest("supplier is null !!!");
            }
            _dataRepository.Add(supplier);
            return CreatedAtRoute("GetCustomer", new { Id = supplier.SupplierID }, supplier);
        }

        [HttpPut]
        [Route("UpdateSupplier/{supplierId}")]
        public IActionResult PutSupplier(long supplierId, [FromBody] Supplier supplier)
        {
            if (supplier == null)
            {
                return BadRequest("supplier is null !!!");
            }
            Supplier supplierToUpdate = _dataRepository.Get(supplierId);
            if (supplierToUpdate == null)
            {
                return NotFound("supplier record not found !!!");
            }
            _dataRepository.Update(supplierToUpdate, supplier);
            return CreatedAtRoute("GetCustomer", new { Id = supplier.SupplierID }, supplier);
        }

        [HttpDelete]
        [Route("DeleteSupplier/{supplierId}")]
        public IActionResult DeleteSupplier(long supplierId)
        {
            Supplier supplier = _dataRepository.Get(supplierId);
            if (supplier == null)
            {
                return NotFound("supplier record not found !!!");
            }
            _dataRepository.Delete(supplier);
            return GetSupplier();
        }

    }
}