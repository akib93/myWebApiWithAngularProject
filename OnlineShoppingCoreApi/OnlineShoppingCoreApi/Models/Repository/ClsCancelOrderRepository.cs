using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsCancelOrderRepository : IDataAccessRepository<CancelOrder>
    {
        readonly OnlineShoppingCoreApiDbContext _cancelOrderContext;

        public ClsCancelOrderRepository(OnlineShoppingCoreApiDbContext context)
        {
            _cancelOrderContext = context;
        }

        public CancelOrder Get(long Id)
        {
            return _cancelOrderContext.CancelOrders.FirstOrDefault(e => e.CancelOrderID == Id);
        }

        public IEnumerable<CancelOrder> GetAll()
        {
            return _cancelOrderContext.CancelOrders.ToList();
        }

        public void Add(CancelOrder entity)
        {
            _cancelOrderContext.CancelOrders.Add(entity);
            _cancelOrderContext.SaveChanges();
        }


        public void Update(CancelOrder dbEntity, CancelOrder entity)
        {
            var cancelOrder = _cancelOrderContext.CancelOrders.Find(dbEntity.CancelOrderID);
            if (cancelOrder != null)
            {
                //dbEntity.UniqueID = entity.UniqueID;
                //dbEntity.DateOfCompliletion = entity.DateOfCompliletion;
                //_cancelOrderContext.SaveChanges();
            }
        }

        public void Delete(CancelOrder entity)
        {
            var purchase = _cancelOrderContext.Purchases.Find(entity.CancelOrderID);
            if (purchase != null)
            {
                _cancelOrderContext.CancelOrders.Remove(entity);
                _cancelOrderContext.SaveChanges();
            }
        }

    }
}
