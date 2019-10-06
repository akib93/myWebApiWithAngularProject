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
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataAccessRepository<Customer> _dataRepository;

        public CustomerController(IDataAccessRepository<Customer> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        [Route("GetCustomer")]
        public IActionResult GetCustomer()
        {
            IEnumerable<Customer> customers = _dataRepository.GetAll();
            return Ok(customers);
        }


        [HttpGet(Name = "GetCustomer")]
        [Route("GetCustomerById/{customerId}")]
        public IActionResult GetCustomerById(long customerId)
        {
            Customer customer = _dataRepository.Get(customerId);
            if (customer == null)
            {
                return NotFound("Customer record not found !!!");
            }
            return Ok(customer);
        }


        [HttpPost]
        [Route("InsertCustomer")]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is null !!!");
            }
            _dataRepository.Add(customer);
            return CreatedAtRoute("GetCustomer", new { Id = customer.CustomerID }, customer);
        }

        [HttpPut]
        [Route("UpdateCustomer/{customerId}")]
        public IActionResult PutCustomer(long customerId, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("customer is null !!!");
            }
            Customer customerToUpdate = _dataRepository.Get(customerId);
            if (customerToUpdate == null)
            {
                return NotFound("customer record not found !!!");
            }
            _dataRepository.Update(customerToUpdate, customer);
            return CreatedAtRoute("GetCustomer", new { Id = customer.CustomerID }, customer);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{customerId}")]
        public IActionResult DeleteCustomer(long customerId)
        {
            Customer customer = _dataRepository.Get(customerId);
            if (customer == null)
            {
                return NotFound("Customer record not found !!!");
            }
            _dataRepository.Delete(customer);
            return GetCustomer();
        }



    }
}