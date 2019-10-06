using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;


namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsBrandDataAccessRepository : IDataAccessRepository<Brand, int>
    {

        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {
            var brand = db.Brands.Find(id);
            if (brand != null)
            {
                db.Brands.Remove(brand);
                db.SaveChanges();
            }
        }

        public IEnumerable<Brand> Get()
        {
            return db.Brands.ToList();
        }

        public Brand Get(int id)
        {
            return db.Brands.Find(id);
        }

        public void Post(Brand entity)
        {
            db.Brands.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Brand entity)
        {
            var brand = db.Brands.Find(id);
            if (brand != null)
            {
                brand.BrandName = entity.BrandName;
                db.SaveChanges();
            }
        }
    }
}