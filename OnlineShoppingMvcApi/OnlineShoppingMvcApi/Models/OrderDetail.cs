using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcApi.Models
{
    public class OrderDetail
    {
        [Key]
        [Display(Name = "Order Detail ID")]
        public int OrderDetailID { get; set; }

        [Display(Name = "Stock ID")]
        public int StockID { get; set; }
        public virtual Stock Stock { get; set; }


        [Display(Name = "Quantity")]
        public float Quantity { get; set; }

        [Display(Name = "Price Per Unit")]
        public decimal PricePerUnit { get; set; }

        [Display(Name = "Total Bill")]
        public decimal TotalBill { get; set; }

        [Display(Name = "Unique Order ID")]
        public int UniqueID { get; set; }

        public string Status { get; set; }

        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }


        //[Display(Name = "Customer ID")]
        //public int? CustomerID { get; set; }
        //public virtual Customer Customer { get; set; }


        //[Display(Name = "Shipping Address")]
        //public string ShippingAddress { get; set; }

        //public virtual ICollection<Shippment> Shippments { get; set; }
        //public virtual ICollection<OrderArchive> OrderArchives { get; set; }
        //public virtual ICollection<CancelOrder> CancelOrders { get; set; }
        //public virtual ICollection<Payment> Payments { get; set; }
    }
}