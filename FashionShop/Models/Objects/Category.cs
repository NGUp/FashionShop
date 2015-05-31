using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.Objects
{
    public class Category
    {
        private string id;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}