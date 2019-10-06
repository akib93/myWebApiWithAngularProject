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
    [RoutePrefix("api/Brand")]
    public class BrandController : ApiController
    {
        private IDataAccessRepository<Brand, int> _repository;

        //Inject the DataAccessReposity using Contruction Injection 
        public BrandController(IDataAccessRepository<Brand, int> r)
        {
            _repository = r;
        }

        [HttpGet]
        [Route("GetBrand", Name = "GetBrand")]
        public IEnumerable<Brand> GetItem()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("GetBrandById/{brandId}")]
        public IHttpActionResult GetBrandById(int brandId)
        {
            return Ok(_repository.Get(brandId));
        }


        [HttpPost]
        [Route("InsertBrand")]
        public IHttpActionResult PostItem(Brand brand)
        {
            _repository.Post(brand);
            return Ok(brand);
        }

        [HttpPut]
        [Route("UpdateBrand/{brandId}")]
        public IHttpActionResult PutBrand(int brandId, Brand brand)
        {
            _repository.Put(brandId, brand);
            return CreatedAtRoute("GetBrand", new { Id = brand.BrandID }, brand);
        }

        [HttpDelete]
        [Route("DeleteBrand/{brandId}")]
        public IHttpActionResult DeleteBrand(int brandId, Brand brand)
        {
            _repository.Delete(brandId);
            return CreatedAtRoute("GetBrand", new { Id = brand.BrandID }, brand);
        }


    }
}
