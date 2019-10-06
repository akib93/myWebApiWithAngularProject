using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcApi.Models
{
    public class Stock
    {
        [Key]
        [Display(Name = "Stock ID")]
        public int StockID { get; set; }

        [Display(Name = "Purchase ID")]
        public int PurchaseID { get; set; }
        public virtual Purchase Purchase { get; set; }

        [Display(Name = "Item ID")]
        public int? ItemID { get; set; }
        public virtual Item Item { get; set; }


        [Display(Name = "Brand ID")]
        public int? BrandID { get; set; }
        public virtual Brand Brand { get; set; }


        [Display(Name = "Available Quantity")]
        public float AvailableQuantity { get; set; }
 
        [Display(Name = "Cost Price Per Unit")]
        public decimal CostPricePerUnit { get; set; }

        [Display(Name = "Selling Price Per Unit")]
        public decimal SellingPricePertUnit { get; set; }
        public decimal Discount { get; set; }
        public decimal MRP { get; set; }

        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}