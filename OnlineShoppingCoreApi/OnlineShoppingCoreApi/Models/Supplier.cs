using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCoreApi.Models
{
    public class Supplier
    {
        [Key]
        [Display(Name = "Supplier ID")]
        public int SupplierID { get; set; }

        [Display(Name = "Name")]
        public string SupplierName { get; set; }

        [Display(Name = "Cell Phone")]
        public string SupplierCellPhone { get; set; }

        [Display(Name = "Email ID")]
        public string SupplierEmail { get; set; }

        [Display(Name = "Address")]
        public string SupplierAddress { get; set; }

        [Display(Name = "Business Address")]
        public string SupplierBusinessAddress { get; set; }

        //public virtual ICollection<Purchase> Purchases { get; set; }
    }
}