using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCoreApi.Models;
using OnlineShoppingCoreApi.Models.Repository;

namespace OnlineShoppingCoreApi.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IDataAccessRepository<Item> _dataRepository;

        public ItemController(IDataAccessRepository<Item> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetItem")]
        public IActionResult GetItem()
        {
            IEnumerable<Item> items = _dataRepository.GetAll();
            return Ok(items);
        }


        [HttpGet(Name = "GetItem")]
        [Route("GetItemById/{itemId}")]
        public IActionResult GetItemById(long itemId)
        {
            Item item = _dataRepository.Get(itemId);
            if (item == null)
            {
                return NotFound("item record not found !!!");
            }
            return Ok(item);
        }


        [HttpPost]
        [Route("InsertItem")]
        public IActionResult PostItem([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("item is null !!!");
            }
            _dataRepository.Add(item);
            return CreatedAtRoute("GetItem", new { Id = item.ItemID}, item);
        }


        [HttpPut]
        [Route("UpdateItem/{itemId}")]
        public IActionResult PutItem(long itemId, [FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("item is null !!!");
            }
            Item itemToUpdate = _dataRepository.Get(itemId);
            if (itemToUpdate == null)
            {
                return NotFound("itemId record not found !!!");
            }
            _dataRepository.Update(itemToUpdate, item);
            return CreatedAtRoute("GetItem", new { Id = item.ItemID }, item);
        }

        [HttpDelete]
        [Route("DeleteItem/{itemId}")]
        public IActionResult DeleteItem(long itemId)
        {
            Item item = _dataRepository.Get(itemId);
            if (item == null)
            {
                return NotFound("Item record not found !!!");
            }
            _dataRepository.Delete(item);
            return GetItem();
        }


    }
}