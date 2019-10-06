using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcApi.Models
{
    public class Payment
    {
        [Key]
        [Display(Name = "Payment ID")]
        public int PaymentID { get; set; }

        [Display(Name = "Order Detail ID")]
        public int UniqueID { get; set; }
        //public virtual OrderDetail OrderDetail { get; set; }


        //[Display(Name = "Order Detail ID")]
        //public int OrderDetailID { get; set; }
        //public virtual OrderDetail OrderDetail { get; set; }


        [Display(Name = "Payment Date")]
        public DateTime DateOfPayment { get; set; }

        [Display(Name = "Bill Before Tax")]
        public decimal BillBeforeTax { get; set; }


        [Display(Name = "Tax Rate")]
        public decimal TaxRate { get; set; }


        [Display(Name = "Total Bill")]
        public decimal TotalBill { get; set; }

    }
}