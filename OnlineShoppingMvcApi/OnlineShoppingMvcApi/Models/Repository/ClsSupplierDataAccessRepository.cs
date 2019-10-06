using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;

namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsSupplierDataAccessRepository : IDataAccessRepository<Supplier, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }


        public void Delete(int id)
        {
            var supplier = db.Suppliers.Find(id);
            if (supplier != null)
            {
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
            }
        }

        public IEnumerable<Supplier> Get()
        {
            return db.Suppliers.ToList();
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.Find(id);
        }

        public void Post(Supplier entity)
        {
            db.Suppliers.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Supplier entity)
        {
            var supplier = db.Suppliers.Find(id);
            if (supplier != null)
            {
                supplier.SupplierName = entity.SupplierName;
                supplier.SupplierCellPhone = entity.SupplierCellPhone;
                supplier.SupplierEmail = entity.SupplierEmail;
                supplier.SupplierAddress = entity.SupplierAddress;
                supplier.SupplierBusinessAddress = entity.SupplierBusinessAddress;
                db.SaveChanges();
            }
        }
    }
}