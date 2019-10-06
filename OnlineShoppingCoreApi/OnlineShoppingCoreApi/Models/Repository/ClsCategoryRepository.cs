using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsCategoryRepository : IDataAccessRepository<Category>
    {
        readonly OnlineShoppingCoreApiDbContext _categoryContext;

        public ClsCategoryRepository(OnlineShoppingCoreApiDbContext context)
        {
            _categoryContext = context;
        }



        public void Add(Category category)
        {
            _categoryContext.Categories.Add(category);
            _categoryContext.SaveChanges();
        }

        public void Delete(Category category)
        {
            _categoryContext.Categories.Remove(category);
            _categoryContext.SaveChanges();
        }

        public Category Get(long Id)
        {
            return _categoryContext.Categories.FirstOrDefault(e => e.CategoryID == Id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryContext.Categories.ToList();
        }

        public void Update(Category dbEntity, Category entity)
        {
            dbEntity.CategoryName = entity.CategoryName;
            dbEntity.QuantityType = entity.QuantityType;

            _categoryContext.SaveChanges();
        }
    }
}
