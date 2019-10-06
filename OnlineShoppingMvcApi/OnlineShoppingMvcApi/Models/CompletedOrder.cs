using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcApi.Models
{
    public class CompletedOrder
    {
        [Key]
        [Display(Name = "Cancel Order ID")]

        public int CompletedOrderID { get; set; }



        [Display(Name = "Unique Order ID")]
        public int UniqueID { get; set; }



        //[Display(Name = "Order Detail ID")]
        //public int OrderDetailID { get; set; }

        //public virtual OrderDetail OrderDetail { get; set; }


        [Display(Name = "Compliletion Date")]

        public DateTime DateOfCompliletion { get; set; }
    }
}