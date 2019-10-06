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
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IDataAccessRepository<Purchase> _dataRepository;

        public PurchaseController(IDataAccessRepository<Purchase> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("Getpurchase")]
        public IActionResult Getpurchase()
        {
            IEnumerable<Purchase> purchase = _dataRepository.GetAll();
            return Ok(purchase);
        }


        [HttpGet(Name = "Getpurchase")]
        [Route("GetpurchaseById/{purchaseId}")]
        public IActionResult GetpurchaseById(long purchaseId)
        {
            Purchase purchase = _dataRepository.Get(purchaseId);
            if (purchase == null)
            {
                return NotFound("purchase record not found !!!");
            }
            return Ok(purchase);
        }


        [HttpPost]
        [Route("InsertPurchase")]
        public IActionResult PostPurchase([FromBody] Purchase purchase)
        {
            if (purchase == null)
            {
                return BadRequest("Purchase is null !!!");
            }
            _dataRepository.Add(purchase);
            return CreatedAtRoute("Getpurchase", new { Id = purchase.PurchaseID }, purchase);
        }

        [HttpPut]
        [Route("UpdatePurchase/{PurchaseID}")]
        public IActionResult PutStock(long PurchaseID, [FromBody] Purchase purchase)
        {
            if (purchase == null)
            {
                return BadRequest("purchase is null !!!");
            }
            Purchase PurchaseToUpdate = _dataRepository.Get(PurchaseID);
            if (PurchaseToUpdate == null)
            {
                return NotFound("purchase record not found !!!");
            }
            _dataRepository.Update(PurchaseToUpdate, purchase);
            return CreatedAtRoute("Getpurchase", new { Id = purchase.PurchaseID }, purchase);
        }

        [HttpDelete]
        [Route("DeletePurchase/{PurchaseID}")]
        public IActionResult DeletePurchse(long PurchaseID)
        {
            Purchase purchase = _dataRepository.Get(PurchaseID);
            if (purchase == null)
            {
                return NotFound("purchase record not found !!!");
            }
            _dataRepository.Delete(purchase);
            return Getpurchase();
        }
    }
}
