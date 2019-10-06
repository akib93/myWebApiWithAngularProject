using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsBrandRepository : IDataAccessRepository<Brand>
    {
        readonly OnlineShoppingCoreApiDbContext _brandContext;

        public ClsBrandRepository(OnlineShoppingCoreApiDbContext context)
        {
            _brandContext = context;
        }

        public void Add(Brand entity)
        {
            _brandContext.Brands.Add(entity);
            _brandContext.SaveChanges();
        }

        public void Delete(Brand entity)
        {
            _brandContext.Brands.Remove(entity);
            _brandContext.SaveChanges();
        }

        public Brand Get(long Id)
        {
            return _brandContext.Brands.FirstOrDefault(e => e.BrandID == Id);
        }

        public IEnumerable<Brand> GetAll()
        {
            return _brandContext.Brands.ToList();
        }

        public void Update(Brand dbEntity, Brand entity)
        {
            dbEntity.BrandName = entity.BrandName;


            _brandContext.SaveChanges();
        }
    }
}
