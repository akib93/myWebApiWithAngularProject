using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCoreApi.Models
{
    public class Item
    {
        [Key]
        [Display(Name = "Item ID")]
        public int ItemID { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }


        //public virtual ICollection<Purchase> Purchases { get; set; }

        [Display(Name = "Category ID")]
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}