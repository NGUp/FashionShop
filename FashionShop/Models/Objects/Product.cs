using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Objects
{
    public class Product
    {
        private string id;

        private string name;

        private string manufacturer;

        private int price;

        private string origin;

        private int views;

        private int sales;

        private string image;

        private int state;

        private int sex;

        public int Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public int Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        public int Views
        {
            get { return views; }
            set { views = value; }
        }

        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}