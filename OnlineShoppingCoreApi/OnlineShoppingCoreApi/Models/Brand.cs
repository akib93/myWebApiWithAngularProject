using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCoreApi.Models
{
    public class Brand
    {
        [Key]
        [Display(Name = "Brand ID")]
        public int BrandID { get; set; }

        [Required]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }

        //public virtual ICollection<Purchase> Purchases { get; set; }
    }
}