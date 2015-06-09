using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Objects
{
    public class Order
    {
        private string customer;

        private string purchaseOrder;

        private string customerName;

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string PurchaseOrder
        {
            get { return purchaseOrder; }
            set { purchaseOrder = value; }
        }

        public string Customer
        {
            get { return customer; }
            set { customer = value; }
        }
    }
}