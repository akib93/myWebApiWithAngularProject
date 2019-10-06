using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;

namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsStockDataAccessRepository : IDataAccessRepository<Stock, int>
    {


        [Dependency]
        public ApplicationDbContext db { get; set; }


        public void Delete(int id)
        {
            var stock = db.Stocks.Find(id);
            if (stock != null)
            {
                db.Stocks.Remove(stock);
                db.SaveChanges();
            }
        }

        public IEnumerable<Stock> Get()
        {
            return db.Stocks.ToList();
        }

        public Stock Get(int id)
        {
            return db.Stocks.Find(id);
        }

        public void Post(Stock entity)
        {
            db.Stocks.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Stock entity)
        {
            var stock = db.Stocks.Find(id);
            if (stock != null)
            {
                stock.PurchaseID = entity.PurchaseID;

                stock.PurchaseID = entity.PurchaseID;
                stock.AvailableQuantity = entity.AvailableQuantity;

                stock.CostPricePerUnit = entity.CostPricePerUnit;
                stock.SellingPricePertUnit = entity.SellingPricePertUnit;
                stock.Discount = entity.Discount;
                stock.MRP = stock.SellingPricePertUnit - stock.Discount;


                db.SaveChanges();
            }
        }
    }
}