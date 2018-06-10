using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryStore.Models
{
    public class BakeryItem
    {
        public int ProductKey { get; set; }
        public String ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}