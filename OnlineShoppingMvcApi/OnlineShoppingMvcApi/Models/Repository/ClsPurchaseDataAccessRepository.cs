using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;
using OnlineShoppingMvcApi.Models;


namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsPurchaseDataAccessRepository : IDataAccessRepository<Purchase, int>
    {

        [Dependency]
        public ApplicationDbContext db { get; set; }



        public void Delete(int id)
        {
            var purchase = db.Purchases.Find(id);
            if (purchase != null)
            {
                db.Purchases.Remove(purchase);
                db.SaveChanges();
            }
        }

        public IEnumerable<Purchase> Get()
        {
            return db.Purchases.ToList();
        }

        public Purchase Get(int id)
        {
            return db.Purchases.Find(id);
        }


        public void Post(Purchase entity)
        {
            entity.DateOfPurchase = DateTime.Now;
            db.Purchases.Add(entity);
            db.SaveChanges();

            //Stock brandCheck = db.Stocks.Where(s => s.BrandID == entity.BrandID).FirstOrDefault();
            //Stock itemCheck = db.Stocks.Where(s => s.ItemID == entity.ItemID).FirstOrDefault();

            Stock brandCheck = db.Stocks.Where(s => s.BrandID == entity.BrandID && s.ItemID == entity.ItemID).FirstOrDefault();

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
                db.Stocks.Add(stock);
                db.SaveChanges();
            }
            else
            {
                Stock stock = db.Stocks.Where(s => s.BrandID == entity.BrandID && s.ItemID == entity.ItemID).FirstOrDefault();
                stock.AvailableQuantity = stock.AvailableQuantity + entity.Quantity;
                db.SaveChanges();
            }
        }


        public void Put(int id, Purchase entity)
        {
            var purchase = db.Purchases.Find(id);
            if (purchase != null)
            {
                purchase.ItemID = entity.ItemID;
                purchase.BrandID = entity.BrandID;

                purchase.SupplierID = entity.SupplierID;
                purchase.Size = entity.Size;
                purchase.Quantity = entity.Quantity;
                purchase.Description = entity.Description;


                purchase.CostPerUnit = entity.CostPerUnit;
                purchase.ImageUrl = entity.ImageUrl;
                purchase.DateOfPurchase = entity.DateOfPurchase;




                db.SaveChanges();
            }
        }
    }
}