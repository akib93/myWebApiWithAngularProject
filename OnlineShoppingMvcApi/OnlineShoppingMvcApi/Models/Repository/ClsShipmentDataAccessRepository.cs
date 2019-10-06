using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;

namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsShipmentDataAccessRepository : IDataAccessRepository<Shippment, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var shipment = db.Shippments.Find(id);
            if (shipment != null)
            {
                db.Shippments.Remove(shipment);
                db.SaveChanges();
            }
        }

        public IEnumerable<Shippment> Get()
        {
            return db.Shippments.ToList();
        }

        public Shippment Get(int id)
        {
            return db.Shippments.Find(id);
        }

        public void Post(Shippment entity)
        {
            db.Shippments.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Shippment entity)
        {

            string action = "Complete";
            Shippment ship = db.Shippments.Where(s => s.UniqueID == id).FirstOrDefault();

            if (action == "Complete")
            {
                OrderDetail orderDetail = db.OrderDetails.Where(s => s.UniqueID == id).FirstOrDefault();
                if (orderDetail != null)
                {
                    orderDetail.Status = "Complete";
                    db.SaveChanges();

                    ship.Status = "Complete";
                    db.SaveChanges();

                    Payment payment = new Payment();
                    payment.UniqueID = orderDetail.UniqueID;
                    payment.BillBeforeTax = orderDetail.TotalBill;
                    payment.TaxRate = ((payment.BillBeforeTax * 15) / 100);
                    payment.TotalBill = payment.BillBeforeTax + payment.TaxRate;
                    payment.DateOfPayment = DateTime.Now;
                    db.Payments.Add(payment);
                    db.SaveChanges();

                    CompletedOrder completed = new CompletedOrder();
                    completed.UniqueID = orderDetail.UniqueID;
                    completed.DateOfCompliletion = DateTime.Now;
                    db.completedOrders.Add(completed);
                    db.SaveChanges();
                }
            }
            else if (action == "Cancel")
            {
                OrderDetail orderDetail = db.OrderDetails.Where(s => s.UniqueID == id).FirstOrDefault();
                if (orderDetail != null)
                {
                    orderDetail.Status = "Cancel";
                    db.SaveChanges();

                    ship.Status = "Cancel";
                    db.SaveChanges();

                    Stock stock = db.Stocks.Where(s => s.StockID == orderDetail.StockID).FirstOrDefault();
                    stock.AvailableQuantity = stock.AvailableQuantity + orderDetail.Quantity;
                    db.SaveChanges();
                }
            }
        }
    }
}