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
    [RoutePrefix("api/Stock")]
    public class StockController : ApiController
    {
        private IDataAccessRepository<Stock, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public StockController(IDataAccessRepository<Stock, int> r)
        {
            _repository = r;
        }



        [HttpGet]
        [Route("GetStock", Name = "GetStock")]
        public IEnumerable<Stock> GetStock()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetStockById/{stockID}")]
        public IHttpActionResult GetStockById(int stockID)
        {
            return Ok(_repository.Get(stockID));
        }


        [HttpPost]
        [Route("InsertStock")]
        public IHttpActionResult PostStock(Stock stock)
        {
            _repository.Post(stock);
            return Ok(stock);
        }



        [HttpPut]
        [Route("UpdateStock/{stockID}")]
        public IHttpActionResult PutStock(int stockID, Stock stock)
        {
            _repository.Put(stockID, stock);
            return CreatedAtRoute("Get", new { Id = stock.StockID }, stock);
        }


        [HttpDelete]
        [Route("DeleteStock/{stockID}")]
        public IHttpActionResult DeleteStock(int stockID, Stock stock)
        {
            _repository.Delete(stockID);
            return CreatedAtRoute("GetStock", new { Id = stock.PurchaseID }, stock);
        }
    }
}
