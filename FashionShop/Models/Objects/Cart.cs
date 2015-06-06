using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Objects
{
    public class Cart
    {
        private Product product;

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }
    }
}