using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;
using OnlineShoppingMvcApi.Models;


namespace OnlineShoppingMvcApi.Models.Repository
{
    public class ClsOrderDetailDataAccessRepository : IDataAccessRepository<OrderDetail, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }




        public IEnumerable<OrderDetail> Get()
        {
            //return db.OrderDetails.Where(s => s.Status == "Pending").ToList();
            return db.OrderDetails.ToList();
        }

        public IEnumerable<OrderDetail> GetAll()
        {

            return db.OrderDetails.ToList();
        }

        public OrderDetail Get(int id)
        {
            return db.OrderDetails.Where(s => s.UniqueID == id).FirstOrDefault();
            //return db.OrderDetails.Find(id);
        }

        public void Post(OrderDetail entity)
        {

            Stock checkStock = db.Stocks.Where(s => s.StockID == entity.StockID).FirstOrDefault();
            float stockToSell = checkStock.AvailableQuantity;
            try
            {
                if(stockToSell>= entity.Quantity)
                {
                    Random random = new Random();
                    int unique1 = random.Next();
                    int uniqueID = unique1;

                    CustomShippingAddress customShipping = new CustomShippingAddress();
                    customShipping.UniqueOrderID = uniqueID;
                    customShipping.CellPhone = "Not Specified";
                    customShipping.ShippingAddress = "Not Specified";
                    db.CustomShippingAddresses.Add(customShipping);
                    db.SaveChanges();


                    Stock stock = db.Stocks.Where(s => s.StockID == entity.StockID).FirstOrDefault();
                    entity.PricePerUnit = stock.SellingPricePertUnit;
                    entity.TotalBill = entity.PricePerUnit * (decimal)entity.Quantity;
                    entity.UniqueID = uniqueID;
                    entity.Status = "Pending";
                    entity.CustomerID = "Not Specified";
                    db.OrderDetails.Add(entity);
                    db.SaveChanges();

                    // We should send uniqueID to the customer table where customer id = current login ID;


                    Stock mainStock = db.Stocks.Where(s => s.StockID == entity.StockID).FirstOrDefault();
                    float availableStock = mainStock.AvailableQuantity;
                    if (availableStock >= entity.Quantity)
                    {
                        mainStock.AvailableQuantity = availableStock - entity.Quantity;
                        db.SaveChanges();
                    }
                    else
                    {

                    }
                }
            }
            catch
            {

            }
        }

        public void Put(int id, OrderDetail entity)
        {
            try
            {
                string action = "Cancel";

                if (action == "Cancel")
                {
                    OrderDetail orderDetail = db.OrderDetails.Where(s => s.UniqueID == id).FirstOrDefault();
                    if (orderDetail != null)
                    {
                        orderDetail.Status = "Cancel";
                        db.SaveChanges();


                        Stock stock = db.Stocks.Where(s => s.StockID == orderDetail.StockID).FirstOrDefault();
                        stock.AvailableQuantity = stock.AvailableQuantity+orderDetail.Quantity;
                        db.SaveChanges();

                        CancelOrder cancelOrder = new CancelOrder();
                        cancelOrder.UniqueID = orderDetail.UniqueID;
                        cancelOrder.DateOfCompliletion = DateTime.Now;
                        db.CancelOrders.Add(cancelOrder);
                        db.SaveChanges();
                    }
                }
                else if (action == "SendToShip")
                {
                    OrderDetail orderDetail = db.OrderDetails.Where(s => s.UniqueID == id).FirstOrDefault();
                    if (orderDetail != null)
                    {
                        orderDetail.Status = "Send To Ship";
                        db.SaveChanges();

                        Shippment ship = new Shippment();
                        ship.Status = "Pending";
                        ship.UniqueID = orderDetail.UniqueID;
                        ship.DateOfCompliletion = DateTime.Now;
                        db.Shippments.Add(ship);
                        db.SaveChanges();
                    }
                }

            }
            catch
            {

            }
        }
        public void Delete(int id)
        {

            OrderDetail orderDetail = db.OrderDetails.Where(s => s.UniqueID == id).FirstOrDefault();
            if (orderDetail != null)
            {
                db.OrderDetails.Remove(orderDetail);
                db.SaveChanges();
            }

        }
    }
}