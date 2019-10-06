using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsItemRepository : IDataAccessRepository<Item>
    {
        readonly OnlineShoppingCoreApiDbContext _categoryContext;

        public ClsItemRepository(OnlineShoppingCoreApiDbContext context)
        {
            _categoryContext = context;
        }



        public void Add(Item item )
        {
            _categoryContext.Items.Add(item);
            _categoryContext.SaveChanges();
        }

        public void Delete(Item item)
        {
            _categoryContext.Items.Remove(item);
            _categoryContext.SaveChanges();
        }

        public Item Get(long Id)
        {
            return _categoryContext.Items.FirstOrDefault(e => e.ItemID == Id);
        }

        public IEnumerable<Item> GetAll()
        {
            return _categoryContext.Items.ToList();
        }

        public void Update(Item dbEntity, Item entity)
        {
            dbEntity.ItemName = entity.ItemName;
            dbEntity.CategoryID = entity.CategoryID;

            _categoryContext.SaveChanges();
        }
    }
}
