using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using OnlineShoppingMvcApi.Models;
using OnlineShoppingMvcApi.Models.Repository;
using System.Web.Http.Description;

using System.Web.Http.Cors;

namespace OnlineShoppingMvcApi.Controllers
{
    //[EnableCors(origins: "http://localhost:4200/", headers:"*", methods:"*")]
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private IDataAccessRepository<Category, int> _repository;
        private ApplicationDbContext db { get; set; }

        //Inject the DataAccessReposity using Contruction Injection 
        public CategoryController(IDataAccessRepository<Category, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetCategory", Name = "Get")]
        public IEnumerable<Category> GetCategory()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetCategoryById/{categoryId}")]
        public IHttpActionResult GetCategoryById(int categoryId)
        {
            return Ok(_repository.Get(categoryId));
        }

        [HttpPost]
        [Route("InsertCategory")]
        public IHttpActionResult PostCategory(Category category)
        {
            _repository.Post(category);
            return Ok(category);
        }

        [HttpPost]
        [Route("InsertCategory2")]
        public IHttpActionResult PostCategory2(List<Category> category)
        {
            foreach (Category category2 in category)
            {
                db.Categories.Add(category2);
            }
            db.SaveChanges();
            return Ok(category);
        }


        [HttpPut]
        [Route("UpdateCategory/{categoryId}")]
        public IHttpActionResult PutProduct(int categoryId, Category category)
        {
            _repository.Put(categoryId, category);
            return CreatedAtRoute("Get", new { Id = category.CategoryID }, category);
        }


        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public IHttpActionResult DeleteProduct(int categoryId, Category category)
        {
            _repository.Delete(categoryId);
            return CreatedAtRoute("Get", new { Id = category.CategoryID }, category);
        }
    }
}
