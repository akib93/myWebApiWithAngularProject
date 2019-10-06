using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;


namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsPaymentDataAccessRepository : IDataAccessRepository<Payment, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var payment = db.Payments.Find(id);
            if (payment != null)
            {
                db.Payments.Remove(payment);
                db.SaveChanges();
            }
        }

        public IEnumerable<Payment> Get()
        {
            return db.Payments.ToList();
        }

        public Payment Get(int id)
        {
            return db.Payments.Find(id);
        }

        public void Post(Payment entity)
        {
            db.Payments.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Payment entity)
        {
            var payment = db.Payments.Find(id);
            if (payment != null)
            {
                //payment.OrderDetailID = entity.OrderDetailID;
                //payment.TaxRate = entity.TaxRate;
                //payment.TotalBill = entity.TotalBill;
                //payment.DateOfPayment = entity.DateOfPayment;
                //db.SaveChanges();
            }
        }
    }
}