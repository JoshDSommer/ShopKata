using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKata.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public double cost { get; set; }
        public int discountQty { get; set; }
        public double discountCost { get; set; }
    }

    public class Cart
    {
        public int productId { get; set; }
        public int qty { get; set; }
    }
}
