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
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IDataAccessRepository<Category> _dataRepository;

        public CategoryController(IDataAccessRepository<Category> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        [Route("GetCategory")]
        public IActionResult GetCategory()
        {
            IEnumerable<Category> category = _dataRepository.GetAll();
            return Ok(category);
        }


        [HttpGet(Name = "Get")]
        [Route("GetCategoryById/{categoryId}")]
        public IActionResult GetCategoryById(long categoryId)
        {
            Category category = _dataRepository.Get(categoryId);
            if (category == null)
            {
                return NotFound("Category record not found !!!");
            }
            return Ok(category);
        }


        [HttpPost]
        [Route("InsertCategory")]
        public IActionResult PostCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category is null !!!");
            }
            _dataRepository.Add(category);
            return CreatedAtRoute("Get", new { Id = category.CategoryID }, category);
        }

        [HttpPut]
        [Route("UpdateCategory/{categoryId}")]
        public IActionResult PutCategory(long categoryId, [FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category is null !!!");
            }
            Category categoryToUpdate = _dataRepository.Get(categoryId);
            if (categoryToUpdate == null)
            {
                return NotFound("Category record not found !!!");
            }
            _dataRepository.Update(categoryToUpdate, category);
            return CreatedAtRoute("Get", new { Id = category.CategoryID }, category);
        }

        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public IActionResult DeleteCategory(long categoryId)
        {
            Category category = _dataRepository.Get(categoryId);
            if (category == null)
            {
                return NotFound("Category record not found !!!");
            }
            _dataRepository.Delete(category);
            return GetCategory();
        }


    }
}