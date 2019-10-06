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
    [RoutePrefix("api/Item")]
    public class ItemController : ApiController
    {
        private IDataAccessRepository<Item, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 

        public ItemController(IDataAccessRepository<Item, int> r)
        {
            _repository = r;
        }


        [HttpGet]
        [Route("GetItem", Name = "GetItem")]
        public IEnumerable<Item> GetItem()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetItemById/{itemId}")]
        public IHttpActionResult GetItemById(int itemId)
        {
            return Ok(_repository.Get(itemId));
        }


        [HttpPost]
        [Route("InsertItem")]
        public IHttpActionResult PostItem(Item item)
        {
            _repository.Post(item);
            return Ok(item);
        }

        [HttpPut]
        [Route("UpdateItem/{itemId}")]
        public IHttpActionResult PutItem(int itemId, Item item)
        {
            _repository.Put(itemId, item);
            return CreatedAtRoute("Get", new { Id = item.ItemID }, item);
        }

        [HttpDelete]
        [Route("DeleteItem/{itemId}")]
        public IHttpActionResult DeleteItem(int itemId, Item Item)
        {
            _repository.Delete(itemId);
            return CreatedAtRoute("GetItem", new { Id = Item.ItemID }, Item);
        }
    }
}
