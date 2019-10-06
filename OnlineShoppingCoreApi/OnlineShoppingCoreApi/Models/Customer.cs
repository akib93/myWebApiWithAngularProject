using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCoreApi.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }


        [Display(Name = "Unique Order ID")]
        public int UniqueID { get; set; }


        [Required]
        [Display(Name = "Customer Name")]
        [MinLength(3, ErrorMessage = "Please Enter a valid Name ,Minimum 3 Characters!!")]
        [MaxLength(20, ErrorMessage = "Name not more than 20 Character !!")]
        public string CustomerName { get; set; }

        [Required]
        [Phone, MaxLength(15, ErrorMessage = "Phone number must be at least 11 digits")]
        [Display(Name = "Cell Phone")]
        public string CustomerCellPhone { get; set; }

        [EmailAddress]
        [Display(Name = "Email Id")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Address")]
        [MinLength(5, ErrorMessage = "Please Enter a valid Name!!")]
        [MaxLength(50, ErrorMessage = "Address not more than 50 Character  !!")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Registration Date")]
        public DateTime DateOfRegistration { get; set; }

        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}