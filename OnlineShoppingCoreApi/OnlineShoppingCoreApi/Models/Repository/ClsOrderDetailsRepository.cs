using OnlineShoppingMvcApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCoreApi.Models.Repository
{
    public class ClsOrderDetailsRepository : IDataAccessRepository<OrderDetail>
    {
        readonly OnlineShoppingCoreApiDbContext _Context;

        public ClsOrderDetailsRepository(OnlineShoppingCoreApiDbContext context)
        {
            _Context = context;
        }

        public OrderDetail Get(long Id)
        {
            return _Context.OrderDetails.Where(s => s.UniqueID == Id).FirstOrDefault();
        }
        public IEnumerable<OrderDetail> Get()
        {
            return _Context.OrderDetails.ToList();
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _Context.OrderDetails.ToList();
        }

        public void Add(OrderDetail entity)
        {
            Stock checkStock = _Context.Stocks.Where(s => s.StockID == entity.StockID).FirstOrDefault();
            float stockToSell = checkStock.AvailableQuantity;
            try
            {
                if (stockToSell >= entity.Quantity)
                {
                    Random random = new Random();
                    int unique1 = random.Next();
                    int uniqueID = unique1;

                    CustomShippingAddress customShipping = new CustomShippingAddress();
                    customShipping.UniqueOrderID = uniqueID;
                    customShipping.CellPhone = "Not Specified";
                    customShipping.ShippingAddress = "Not Specified";
                    _Context.CustomShippingAddress.Add(customShipping);
                    _Context.SaveChanges();


                    Stock stock = _Context.Stocks.Where(s => s.StockID == entity.StockID).FirstOrDefault();
                    entity.PricePerUnit = stock.SellingPricePertUnit;
                    entity.TotalBill = entity.PricePerUnit * (decimal)entity.Quantity;
                    entity.UniqueID = uniqueID;
                    entity.Status = "Pending";
                    entity.CustomerID = "Not Specified";
                    _Context.OrderDetails.Add(entity);
                    _Context.SaveChanges();

                    // We should send uniqueID to the customer table where customer id = current login ID;


                    Stock mainStock = _Context.Stocks.Where(s => s.StockID == entity.StockID).FirstOrDefault();
                    float availableStock = mainStock.AvailableQuantity;
                    if (availableStock >= entity.Quantity)
                    {
                        mainStock.AvailableQuantity = availableStock - entity.Quantity;
                        _Context.SaveChanges();
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


        public void Update(OrderDetail dbEntity, OrderDetail entity)
        {
            try
            {
                string action = "SendToShip";

                if (action == "Complete")
                {
                    OrderDetail orderDetail = _Context.OrderDetails.Where(s => s.UniqueID == dbEntity.UniqueID).FirstOrDefault();
                    if (orderDetail != null)
                    {
                        orderDetail.Status = "Complete";
                        _Context.SaveChanges();

                        CompletedOrder completed = new CompletedOrder();
                        completed.UniqueID = orderDetail.UniqueID;
                        completed.DateOfCompliletion = DateTime.Now;
                        _Context.CompletedOrders.Add(completed);
                        _Context.SaveChanges();
                    }
                }
                else if (action == "Cancel")
                {
                    OrderDetail orderDetail = _Context.OrderDetails.Where(s => s.UniqueID == entity.UniqueID).FirstOrDefault();
                    if (orderDetail != null)
                    {
                        orderDetail.Status = "Cancel";
                        _Context.SaveChanges();


                        CancelOrder cancelOrder = new CancelOrder();
                        cancelOrder.UniqueID = orderDetail.UniqueID;
                        cancelOrder.DateOfCompliletion = DateTime.Now;
                        _Context.CancelOrders.Add(cancelOrder);
                        _Context.SaveChanges();
                    }
                }
                else if (action == "SendToShip")
                {
                    OrderDetail orderDetail = _Context.OrderDetails.Where(s => s.UniqueID == dbEntity.UniqueID).FirstOrDefault();
                    if (orderDetail != null)
                    {
                        orderDetail.Status = "Send To Ship";
                        _Context.SaveChanges();


                        Shippment ship = new Shippment();
                        ship.Status = "Pending";
                        ship.UniqueID = orderDetail.UniqueID;
                        ship.DateOfCompliletion = DateTime.Now;
                        _Context.Shippments.Add(ship);
                        _Context.SaveChanges();
                    }
                }

            }
            catch
            {

            }
        }


        public void Delete(OrderDetail entity)
        {
            OrderDetail orderDetail = _Context.OrderDetails.Where(s => s.UniqueID == entity.UniqueID).FirstOrDefault();
            if (orderDetail != null)
            {
                _Context.OrderDetails.Remove(orderDetail);
                _Context.SaveChanges();
            }
        }

    }
}
