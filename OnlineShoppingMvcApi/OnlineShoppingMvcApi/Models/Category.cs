using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcApi.Models
{
    public class Category
    {
        //[Key]
        //[Display(Name = "Category ID")]

        public int CategoryID { get; set; }

        //[Required]
        //[Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        //[Required]
        //[Display(Name = "QuantityType")]
        public string QuantityType { get; set; }

        //public virtual ICollection<Item> Items { get; set; }
    }
}