using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Microsoft.Practices.Unity;
using OnlineShoppingMvcApi.Models;


namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsCustomerDataAccessRepository : IDataAccessRepository<Customer, int>
    {

        [Dependency]
        public ApplicationDbContext db { get; set; }
        public void Delete(int id)
        {

            var customer = db.Customers.Find(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public IEnumerable<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public void Post(Customer entity)
        {

            db.Customers.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Customer entity)
        {
            string action = "Login";
            // here action will be the Logged ID;
            if(action == "Login")
            {
                Customer customer = db.Customers.Where(s => s.UniqueOrderID == id).FirstOrDefault();
                customer.CustomerCellPhone = entity.CustomerCellPhone;
                customer.CustomerAddress = entity.CustomerAddress;
                db.SaveChanges();


                OrderDetail order = new OrderDetail();
                order.CustomerID = action;
                db.SaveChanges();
            }
            else if(action == "Custom")
            {
                CustomShippingAddress custom = db.CustomShippingAddresses.Where(s => s.UniqueOrderID == id).FirstOrDefault();
                custom.CellPhone = entity.CustomerCellPhone;
                custom.ShippingAddress = entity.CustomerAddress;
                db.SaveChanges();


                OrderDetail order = db.OrderDetails.Where(s => s.UniqueID == id).FirstOrDefault();
                order.CustomerID = "Custom Address Used";
                db.SaveChanges();
            }





            //var customer = db.Customers.Find(id);
            //if (customer != null)
            //{
            //    //customer.CustomerAddress = entity.CustomerAddress;
            //    //customer.CustomerName = entity.CustomerName;
            //    //customer.CustomerCellPhone = entity.CustomerCellPhone;
            //    //customer.CustomerEmail = entity.CustomerEmail;
            //    //customer.CustomerAddress = entity.CustomerAddress;
            //    //customer.DateOfRegistration = entity.DateOfRegistration;

            //    db.SaveChanges();
            //}
        }
    }
}