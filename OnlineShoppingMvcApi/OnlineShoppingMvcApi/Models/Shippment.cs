using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcApi.Models
{
    public class Shippment
    {
        [Key]
        [Display(Name = "Shippment ID")]
        public int ShippmentID { get; set; }

        [Display(Name = "Unique Order ID")]
        public int UniqueID { get; set; }
        //public virtual OrderDetail OrderDetail { get; set; }



        //[Display(Name = "Order Detail ID")]
        //public int OrderDetailID { get; set; }
        ////public virtual OrderDetail OrderDetail { get; set; }


        [Display(Name = "Compliletion Date")]
        public DateTime DateOfCompliletion { get; set; }

        public string Status { get; set; }
    }
}