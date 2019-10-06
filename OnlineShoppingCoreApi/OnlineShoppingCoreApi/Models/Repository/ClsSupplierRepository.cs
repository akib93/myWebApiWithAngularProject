using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsSupplierRepository : IDataAccessRepository<Supplier>
    {
        readonly OnlineShoppingCoreApiDbContext _SupplierContext;

        public ClsSupplierRepository(OnlineShoppingCoreApiDbContext context)
        {
            _SupplierContext = context;
        }
        public void Add(Supplier entity)
        {
            _SupplierContext.Suppliers.Add(entity);
            _SupplierContext.SaveChanges();
        }

        public void Delete(Supplier entity)
        {
            _SupplierContext.Suppliers.Remove(entity);
            _SupplierContext.SaveChanges();
        }

        public Supplier Get(long Id)
        {
            return _SupplierContext.Suppliers.FirstOrDefault(e => e.SupplierID == Id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _SupplierContext.Suppliers.ToList();
        }

        public void Update(Supplier dbEntity, Supplier entity)
        {
            dbEntity.SupplierName = entity.SupplierName;
            dbEntity.SupplierCellPhone = entity.SupplierCellPhone;
            dbEntity.SupplierEmail = entity.SupplierEmail;
            dbEntity.SupplierAddress = entity.SupplierAddress;
            dbEntity.SupplierBusinessAddress = entity.SupplierBusinessAddress;

            _SupplierContext.SaveChanges();
        }
    }
}
