using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsShippmentRepository : IDataAccessRepository<Shippment>
    {
        readonly OnlineShoppingCoreApiDbContext _categoryContext;

        public ClsShippmentRepository(OnlineShoppingCoreApiDbContext context)
        {
            _categoryContext = context;
        }

        public void Add(Shippment entity)
        {
            _categoryContext.Shippments.Add(entity);
            _categoryContext.SaveChanges();
        }

        public void Delete(Shippment entity)
        {
            var shipment = _categoryContext.Shippments.Find(entity.ShippmentID);
            if (shipment != null)
            {

                _categoryContext.Shippments.Remove(shipment);
                _categoryContext.SaveChanges();
            }
        }

        public Shippment Get(long Id)
        {
            return _categoryContext.Shippments.FirstOrDefault(e => e.ShippmentID == Id);
        }

        public IEnumerable<Shippment> GetAll()
        {
            return _categoryContext.Shippments.ToList();
        }

        public void Update(Shippment dbEntity, Shippment entity)
        {
            string action = "Complete";
            Shippment ship = _categoryContext.Shippments.Where(s => s.UniqueID == dbEntity.UniqueID).FirstOrDefault();
            if(action== "Complete")
            {
                OrderDetail orderDetail = _categoryContext.OrderDetails.Where(s => s.UniqueID == dbEntity.UniqueID).FirstOrDefault();
                if (orderDetail != null)
                {
                    orderDetail.Status= "Complete";
                    _categoryContext.SaveChanges();

                    ship.Status= "Complete";
                    _categoryContext.SaveChanges();


                    Payment payment = new Payment();
                    payment.UniqueID = orderDetail.UniqueID;
                    payment.BillBeforeTax = orderDetail.TotalBill;
                    payment.TaxRate = ((payment.BillBeforeTax * 15) / 100);
                    payment.TotalBill = payment.BillBeforeTax + payment.TaxRate;
                    payment.DateOfPayment = DateTime.Now;
                    _categoryContext.Payments.Add(payment);
                    _categoryContext.SaveChanges();
                }
            }

            else if(action== "Cancel")
            {
                OrderDetail orderDetail = _categoryContext.OrderDetails.Where(s => s.UniqueID == dbEntity.UniqueID).FirstOrDefault();
                if (orderDetail != null)
                {
                    orderDetail.Status = "Cancel";
                    _categoryContext.SaveChanges();

                    ship.Status = "Cancel";
                    _categoryContext.SaveChanges();
                }
            }
        }
    }
}
