using ShopKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopKata.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private Product[] Products = new Product[] {
         new Product{ name = "A", cost = 50, id = 1,discountQty=3, discountCost=43.333},
         new Product{ name = "B", cost = 30, id = 2,discountQty=2, discountCost=22.5 },
         new Product{ name = "C", cost = 20, id = 3,discountQty=0 },
         new Product{ name = "D", cost = 10, id = 4,discountQty=0 }
         };

        // GET api/values
        public Product[] Get()
        {
            //get all products.
            return Products;
        }

        [HttpPost]
        [Route("GetTotal")]
        public double GetTotal(List<Cart> cart)
        {
            double total = 0;
            //loop through cart Items and add up total
            foreach (Cart item in cart)
            {
                total += ItemTotal(item);
            }
            return total;
        }

        private double ItemTotal(Cart item)
        {
            //get corrisponding product to the cart item.
           var product = Products.Where(x => x.id == item.productId).First();
            //check to make sure product exitst
            if (product == null)
                return 0;

            //if the prodcut has a discount qty, and the cart item qty is greater than or equal to that
            if (product.discountQty > 0 && item.qty>= product.discountQty)
            {
                //return the discounted cost for all items
                return product.discountCost * item.qty;
            }
            else
            {
                //return the non discounted price
                return product.cost * item.qty;
            }
        }
    }
}
