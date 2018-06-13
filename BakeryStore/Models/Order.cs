using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryStore.Models
{
    public class Order
    {

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal GrandTotal { set; get; }
        

    }
}
