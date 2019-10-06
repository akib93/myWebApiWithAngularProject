using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsPurchaseRepository : IDataAccessRepository<Purchase>
    {
        readonly OnlineShoppingCoreApiDbContext _categoryContext;

        public ClsPurchaseRepository(OnlineShoppingCoreApiDbContext context)
        {
            _categoryContext = context;
        }


        public IEnumerable<Purchase> GetAll()
        {
            return _categoryContext.Purchases.ToList();
        }

        public Purchase Get(long Id)
        {
            return _categoryContext.Purchases.Find(Id);
            //return _categoryContext.Purchases.FirstOrDefault(e => e.PurchaseID == Id);
        }

        public void Add(Purchase entity)
        {
            entity.DateOfPurchase = DateTime.Now;
            _categoryContext.Purchases.Add(entity);
            _categoryContext.SaveChanges();

            Stock brandCheck = _categoryContext.Stocks.Where(s => s.BrandID == entity.BrandID && s.ItemID == entity.ItemID).FirstOrDefault();

            if (brandCheck == null)
            {
                Stock stock = new Stock();
                stock.PurchaseID = entity.PurchaseID;
                stock.AvailableQuantity = entity.Quantity;
                stock.CostPricePerUnit = entity.CostPerUnit;
                stock.SellingPricePertUnit = entity.CostPerUnit + (entity.CostPerUnit * 10 / 100);
                stock.Discount = 0;
                stock.MRP = stock.SellingPricePertUnit - stock.Discount;
                stock.ItemID = entity.ItemID;
                stock.BrandID = entity.BrandID;
                _categoryContext.Stocks.Add(stock);
                _categoryContext.SaveChanges();
            }
            else
            {
                Stock stock = _categoryContext.Stocks.Where(s => s.BrandID == entity.BrandID && s.ItemID == entity.ItemID).FirstOrDefault();
                stock.AvailableQuantity = stock.AvailableQuantity + entity.Quantity;
                _categoryContext.SaveChanges();
            }
        }



        public void Update(Purchase dbEntity, Purchase entity)
        {
            var purchase = _categoryContext.Purchases.Find(dbEntity.PurchaseID);
            if (purchase != null)
            {

                dbEntity.ItemID = entity.ItemID;
                dbEntity.BrandID = entity.BrandID;

                dbEntity.SupplierID = entity.SupplierID;
                dbEntity.Size = entity.Size;
                dbEntity.Quantity = entity.Quantity;
                dbEntity.Description = entity.Description;
                dbEntity.CostPerUnit = entity.CostPerUnit;
                dbEntity.ImageUrl = entity.ImageUrl;
                dbEntity.DateOfPurchase = entity.DateOfPurchase;

                _categoryContext.SaveChanges();
            }
        }


        public void Delete(Purchase entity)
        {
            var purchase = _categoryContext.Purchases.Find(entity.PurchaseID);
            if (purchase != null)
            {
                _categoryContext.Purchases.Remove(entity);
                _categoryContext.SaveChanges();
            }
        }
    }
}
