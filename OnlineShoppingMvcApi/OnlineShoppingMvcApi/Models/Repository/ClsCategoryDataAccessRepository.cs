using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;


namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsCategoryDataAccessRepository : IDataAccessRepository<Category, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        public IEnumerable<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public void Post(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public void Post2(List<Category> entity)
        {
            foreach (Category category in entity)
            {
                db.Categories.Add(category);
            }
            db.SaveChanges();
        }

        public void Put(int id, Category entity)
        {
            var category = db.Categories.Find(id);
            if (category != null)
            {
                category.CategoryName = entity.CategoryName;
                category.QuantityType = entity.QuantityType;
                db.SaveChanges();
            }
        }
    }
}