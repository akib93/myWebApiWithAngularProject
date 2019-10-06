using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingMvcApi.Models
{
    public class CustomShippingAddress
    {
        public int CustomShippingAddressID { get; set; }
        public int UniqueOrderID { get; set; }
        public string CellPhone { get; set; }
        public string ShippingAddress { get; set; }
    }
}