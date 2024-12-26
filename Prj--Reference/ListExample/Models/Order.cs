using System;
using System.Collections.Generic;

#nullable disable

namespace ListExample.Models
{
    public partial class Order
    {
        public string Number { get; set; }
        public DateTime ShippingDate { get; set; }
        public string ShippingAddress { get; set; }
        public string CustomerSignature { get; set; }
        public string CustomerNumber { get; set; }
        public decimal Total { get; set; }
    }
}
