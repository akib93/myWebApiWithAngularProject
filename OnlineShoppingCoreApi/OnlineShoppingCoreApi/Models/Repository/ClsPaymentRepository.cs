using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsPaymentRepository : IDataAccessRepository<Payment>
    {

        readonly OnlineShoppingCoreApiDbContext _categoryContext;

        public ClsPaymentRepository(OnlineShoppingCoreApiDbContext context)
        {
            _categoryContext = context;
        }


        public Payment Get(long Id)
        {
            return _categoryContext.Payments.Find(Id);
            //return _categoryContext.Payments.FirstOrDefault(e => e.PaymentID == Id);
        }

        public IEnumerable<Payment> GetAll()
        {
            return _categoryContext.Payments.ToList();

        }

        public void Add(Payment entity)
        {
            _categoryContext.Payments.Add(entity);
            _categoryContext.SaveChanges();
        }


        public void Update(Payment dbEntity, Payment entity)
        {
            var payment = _categoryContext.Payments.Find(dbEntity.PaymentID);
            if (payment != null)
            {
                //dbEntity.UniqueID = entity.UniqueID;
                //dbEntity.TaxRate = entity.TaxRate;
                //dbEntity.TotalBill = entity.TotalBill;
                //dbEntity.DateOfPayment = entity.DateOfPayment;
                //_categoryContext.SaveChanges();
            }
        }

        public void Delete(Payment entity)
        {
            var payment = _categoryContext.Payments.Find(entity.PaymentID);
            if (payment != null)
            {
                _categoryContext.Payments.Remove(payment);
                _categoryContext.SaveChanges();
            }
        }

    }
}
