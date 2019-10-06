using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsCustomerRepository : IDataAccessRepository<Customer>
    {

        readonly OnlineShoppingCoreApiDbContext _CustomerContext;

        public ClsCustomerRepository(OnlineShoppingCoreApiDbContext context)
        {
            _CustomerContext = context;
        }



        public void Add(Customer entity)
        {
            _CustomerContext.Customers.Add(entity);
            _CustomerContext.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _CustomerContext.Customers.Remove(entity);
            _CustomerContext.SaveChanges();
        }

        public Customer Get(long Id)
        {
            return _CustomerContext.Customers.FirstOrDefault(e => e.CustomerID == Id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _CustomerContext.Customers.ToList();
        }

        public void Update(Customer dbEntity, Customer entity)
        {
            dbEntity.CustomerName = entity.CustomerName;
            dbEntity.CustomerCellPhone = entity.CustomerCellPhone;
            dbEntity.CustomerEmail = entity.CustomerEmail;
            dbEntity.CustomerAddress = entity.CustomerAddress;
            dbEntity.DateOfRegistration = entity.DateOfRegistration;

            _CustomerContext.SaveChanges();
        }
    }
}
