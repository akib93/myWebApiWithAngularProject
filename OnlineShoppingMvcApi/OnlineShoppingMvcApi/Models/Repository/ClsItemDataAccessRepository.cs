using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;


namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsItemDataAccessRepository : IDataAccessRepository<Item, int>
    {

        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var item = db.Items.Find(id);
            if (item != null)
            {
                db.Items.Remove(item);
                db.SaveChanges();
            }
        }

        public IEnumerable<Item> Get()
        {
            return db.Items.ToList();
        }

        public Item Get(int id)
        {
            return db.Items.Find(id);
        }

        public void Post(Item entity)
        {
            db.Items.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Item entity)
        {
            var item = db.Items.Find(id);
            if (item != null)
            {
                item.ItemName = entity.ItemName;
                item.CategoryID = entity.CategoryID;
                db.SaveChanges();
            }
        }
    }
}