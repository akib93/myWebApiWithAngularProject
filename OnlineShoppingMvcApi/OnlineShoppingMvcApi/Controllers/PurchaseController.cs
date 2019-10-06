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
    [RoutePrefix("api/Purchase")]

    public class PurchaseController : ApiController
    {
        private IDataAccessRepository<Purchase, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public PurchaseController(IDataAccessRepository<Purchase, int> r)
        {
            _repository = r;
        }



        [HttpGet]
        [Route("GetPurchase", Name = "GetPurchase")]
        public IEnumerable<Purchase> GetPurchase()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetPurchaseById/{purchaseID}")]
        public IHttpActionResult GetPurchaseById(int purchaseID)
        {
            return Ok(_repository.Get(purchaseID));
        }


        [HttpPost]
        [Route("InsertPurchase")]
        public IHttpActionResult PostPurchase(Purchase purchase)
        {
            _repository.Post(purchase);
            return Ok(purchase);
        }



        [HttpPut]
        [Route("UpdatePurchase/{purchaseID}")]
        public IHttpActionResult PutPurchase(int purchaseID, Purchase purchase)
        {
            _repository.Put(purchaseID, purchase);
            return CreatedAtRoute("Get", new { Id = purchase.ItemID }, purchase);
        }


        [HttpDelete]
        [Route("DeletePurchase/{purchaseID}")]
        public IHttpActionResult DeleteItem(int purchaseID, Purchase purchase)
        {
            _repository.Delete(purchaseID);
            return CreatedAtRoute("GetPurchase", new { Id = purchase.PurchaseID }, purchase);
        }
    }
}
