using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;


namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsCancelOrderDataAccessRepository : IDataAccessRepository<CancelOrder, int>
    {

        [Dependency]
        public ApplicationDbContext db { get; set; }


        void IDataAccessRepository<CancelOrder, int>.Delete(int id)
        {
            var cancleOrder = db.CancelOrders.Find(id);
            if (cancleOrder != null)
            {
                db.CancelOrders.Remove(cancleOrder);
                db.SaveChanges();
            }
        }

        IEnumerable<CancelOrder> IDataAccessRepository<CancelOrder, int>.Get()
        {
            return db.CancelOrders.ToList();
        }

        CancelOrder IDataAccessRepository<CancelOrder, int>.Get(int id)
        {
            return db.CancelOrders.Find(id);
        }

        void IDataAccessRepository<CancelOrder, int>.Post(CancelOrder entity)
        {
            db.CancelOrders.Add(entity);
            db.SaveChanges();
        }

        void IDataAccessRepository<CancelOrder, int>.Put(int id, CancelOrder entity)
        {
            var cancleOrder = db.CancelOrders.Find(id);
            if (cancleOrder != null)
            {
                //cancleOrder.OrderDetailID = entity.OrderDetailID;

                //cancleOrder.DateOfCompliletion = entity.DateOfCompliletion;



                //db.SaveChanges();
            }
        }
    }
}