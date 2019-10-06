using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcApi.Models
{
    public class Purchase
    {
        [Key]
        [Display(Name = "Purchase ID")]
        public int PurchaseID { get; set; }


        [Display(Name = "Item ID")]
        public int? ItemID { get; set; }
        public virtual Item Item { get; set; }


        [Display(Name = "Brand ID")]
        public int? BrandID { get; set; }
        public virtual Brand Brand { get; set; }


        [Display(Name = "Supplier ID")]
        public int? SupplierID { get; set; }
        public virtual Supplier Supplier { get; set; }

        public string Size { get; set; }
        public float Quantity { get; set; }
        public string Description { get; set; }


        [Display(Name = "Cost Per Unit")]
        public decimal CostPerUnit { get; set; }


        [Display(Name = "Image")]
        public string ImageUrl { get; set; }


        [Display(Name = "Purchase Date")]
        public DateTime DateOfPurchase { get; set; }

        //public virtual ICollection<Stock> Stocks { get; set; }
    }
}