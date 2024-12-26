using System;
using System.Collections.Generic;

#nullable disable

namespace ListExample.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string ProductNumber { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string Remark { get; set; }
    }
}
