using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsStockRepository:IDataAccessRepository<Stock>
    {

        readonly OnlineShoppingCoreApiDbContext _categoryContext;

        public ClsStockRepository(OnlineShoppingCoreApiDbContext context)
        {
            _categoryContext = context;
        }

        public void Add(Stock stock)
        {
            _categoryContext.Stocks.Add(stock);
            _categoryContext.SaveChanges();
        }

        public void Delete(Stock stock)
        {
            _categoryContext.Stocks.Remove(stock);
            _categoryContext.SaveChanges();
        }

        public Stock Get(long Id)
        {
            return _categoryContext.Stocks.FirstOrDefault(e => e.StockID == Id);
        }

        public IEnumerable<Stock> GetAll()
        {
            return _categoryContext.Stocks.ToList();
        }

        public void Update(Stock dbEntity, Stock entity)
        {
            dbEntity.PurchaseID = entity.PurchaseID;
            dbEntity.AvailableQuantity = entity.AvailableQuantity;

            dbEntity.CostPricePerUnit = entity.CostPricePerUnit;
            dbEntity.SellingPricePertUnit = entity.SellingPricePertUnit;

            dbEntity.Discount = entity.Discount;
            dbEntity.MRP = dbEntity.SellingPricePertUnit - dbEntity.Discount;

            _categoryContext.SaveChanges();
        }
    }
}
