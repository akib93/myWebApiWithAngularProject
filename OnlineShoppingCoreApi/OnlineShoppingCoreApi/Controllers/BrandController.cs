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
    [Route("api/Brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IDataAccessRepository<Brand> _dataRepository;

        public BrandController(IDataAccessRepository<Brand> dataRepository)
        {
            _dataRepository = dataRepository;
        }


        [HttpGet]
        [Route("GetBrand")]
        public IActionResult GetBrand()
        {
            IEnumerable<Brand> brands = _dataRepository.GetAll();
            return Ok(brands);
        }


        [HttpGet(Name = "GetBrand")]
        [Route("GetBrandById/{brandId}")]
        public IActionResult GetBrandById(long brandId)
        {
            Brand brand = _dataRepository.Get(brandId);
            if (brand == null)
            {
                return NotFound("Brand record not found !!!");
            }
            return Ok(brand);
        }


        [HttpPost]
        [Route("InsertBrand")]
        public IActionResult PostBrand([FromBody] Brand brand)
        {
            if (brand == null)
            {
                return BadRequest("Brand is null !!!");
            }
            _dataRepository.Add(brand);
            return CreatedAtRoute("GetBrand", new { Id = brand.BrandID }, brand);
        }

        [HttpPut]
        [Route("UpdateBrand/{brandId}")]
        public IActionResult PutBrand(long brandId, [FromBody]  Brand brand)
        {
            if (brand == null)
            {
                return BadRequest("Brand is null !!!");
            }
            Brand brandToUpdate = _dataRepository.Get(brandId);
            if (brandToUpdate == null)
            {
                return NotFound("Brand record not found !!!");
            }
            _dataRepository.Update(brandToUpdate, brand);
            return CreatedAtRoute("GetBrand", new { Id = brand.BrandID }, brand);
        }

        [HttpDelete]
        [Route("DeleteBrand/{brandId}")]
        public IActionResult DeleteBrand(long brandId)
        {
            Brand brand = _dataRepository.Get(brandId);
            if (brand == null)
            {
                return NotFound("brand record not found !!!");
            }
            _dataRepository.Delete(brand);
            return GetBrand();
        }

    }
}