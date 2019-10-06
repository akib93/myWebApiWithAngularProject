using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCoreApi.Models
{
    public class CancelOrder
    {

        [Key]
        [Display(Name = "Cancel Order ID")]
        public int CancelOrderID { get; set; }

        [Display(Name = "Unique Order ID")]
        public int UniqueID { get; set; }

        //public virtual OrderDetail OrderDetail { get; set; }

        [Display(Name = "Compliletion Date")]
        public DateTime DateOfCompliletion { get; set; }
    }
}