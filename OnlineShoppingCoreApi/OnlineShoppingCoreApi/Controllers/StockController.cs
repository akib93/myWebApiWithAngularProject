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
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IDataAccessRepository<Stock> _dataRepository;

        public StockController(IDataAccessRepository<Stock> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetStock")]
        public IActionResult GetStock()
        {
            IEnumerable<Stock> stocks = _dataRepository.GetAll();
            return Ok(stocks);
        }


        [HttpGet(Name = "GetStock")]
        [Route("GetStockById/{StockId}")]
        public IActionResult GetStockById(long StockId)
        {
            Stock stock = _dataRepository.Get(StockId);
            if (stock == null)
            {
                return NotFound("stock record not found !!!");
            }
            return Ok(stock);
        }


        [HttpPost]
        [Route("InsertStock")]
        public IActionResult PostStock([FromBody] Stock stock)
        {
            if (stock == null)
            {
                return BadRequest("stock is null !!!");
            }
            _dataRepository.Add(stock);
            return CreatedAtRoute("GetStock", new { Id = stock.StockID }, stock);
        }

        [HttpPut]
        [Route("UpdateStock/{StockId}")]
        public IActionResult PutStock(long StockId, [FromBody] Stock stock)
        {
            if (stock == null)
            {
                return BadRequest("stock is null !!!");
            }
            Stock StockToUpdate = _dataRepository.Get(StockId);
            if (StockToUpdate == null)
            {
                return NotFound("Stock record not found !!!");
            }
            _dataRepository.Update(StockToUpdate, stock);
            return CreatedAtRoute("GetStock", new { Id = stock.StockID }, stock);
        }

        [HttpDelete]
        [Route("DeleteStock/{StockId}")]
        public IActionResult DeleteStock(long StockId)
        {
            Stock stock = _dataRepository.Get(StockId);
            if (stock == null)
            {
                return NotFound("stock record not found !!!");
            }
            _dataRepository.Delete(stock);
            return GetStock();
        }
    }
}