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
    [RoutePrefix("api/Supplier")]
    public class SupplierController : ApiController
    {
        private IDataAccessRepository<Supplier, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public SupplierController(IDataAccessRepository<Supplier, int> r)
        {
            _repository = r;
        }


        [HttpGet]
        [Route("GetSupplier", Name = "GetSupplier")]
        public IEnumerable<Supplier> GetSupplier()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetSupplierById/{itemId}")]
        public IHttpActionResult GetSupplierById(int supplierId)
        {
            return Ok(_repository.Get(supplierId));
        }

        [HttpPost]
        [Route("InsertSupplier")]
        public IHttpActionResult PostItem(Supplier supplier)
        {
            _repository.Post(supplier);
            return Ok(supplier);
        }

        [HttpPut]
        [Route("UpdateSupplier/{supplierId}")]
        public IHttpActionResult PutItem(int supplierId, Supplier supplier)
        {
            _repository.Put(supplierId, supplier);
            return CreatedAtRoute("Get", new { Id = supplier.SupplierID }, supplier);
        }

        [HttpDelete]
        [Route("DeleteSupplier/{supplierId}")]
        public IHttpActionResult DeleteSupplier(int supplierId, Supplier supplier)
        {
            _repository.Delete(supplierId);
            return CreatedAtRoute("GetItem", new { Id = supplier.SupplierID }, supplier);
        }

    }
}
