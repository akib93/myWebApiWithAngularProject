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
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private IDataAccessRepository<Customer, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 
        public CustomerController(IDataAccessRepository<Customer, int> r)
        {
            _repository = r;
        }


        [HttpGet]
        [Route("GetCustomer", Name = "GetCustomer")]
        public IEnumerable<Customer> GetCustomer()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetCustomerById/{customerId}")]
        public IHttpActionResult GetCustomerById(int customerId)
        {
            return Ok(_repository.Get(customerId));
        }


        [HttpPost]
        [Route("InsertCustomer")]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            _repository.Post(customer);
            return Ok(customer);
        }

        [HttpPut]
        [Route("UpdateCustomer/{customerId}")]
        public IHttpActionResult PutCustomer(int customerId, Customer customer)
        {
            _repository.Put(customerId, customer);
            return CreatedAtRoute("GetCustomer", new { Id = customer.CustomerID }, customer);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{customerId}")]
        public IHttpActionResult DeleteCustomer(int customerId, Customer customer)
        {
            _repository.Delete(customerId);
            return CreatedAtRoute("GetCustomer", new { Id = customer.CustomerID }, customer);
        }
    }
}
