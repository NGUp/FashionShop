using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using Newtonsoft.Json.Linq;
using FashionShop.Models.Objects;
using FashionShop.Models;

namespace FashionShop.Controllers
{
    public class CartController : Controller
    {
        private void processSession()
        {
            if (Request.Params["cart"] == null)
            {
                Response.Redirect("/index/cart");
            }

            string json = Request.Params["cart"];
            var objects = JArray.Parse(json);

            Hashtable cart = new Hashtable();

            foreach (JObject root in objects)
            {
                Cart obj = new Cart();

                foreach (KeyValuePair<String, JToken> app in root)
                {
                    if (app.Key == "Quantity")
                    {
                        obj.Quantity = Int32.Parse(app.Value.ToString());
                    }
                    else if (app.Key == "Product")
                    {
                        JObject product = JObject.Parse(app.Value.ToString());
                        obj.Product = new Product();
                        obj.Product.Id = (string)product["Id"];
                    }
                }

                if (obj.Quantity > 0)
                {
                    cart[obj.Product.Id] = obj.Quantity;
                }
            }

            Session["PRODUCTS"] = cart;
        }

        [HttpGet]
        public void refresh()
        {
            (Session["PRODUCTS"] as Hashtable).Clear();
            Response.Redirect("/", false);
        }

        [HttpPost]
        public void update()
        {
            this.processSession();

            Response.Redirect("/");
        }

        [HttpPost]
        public void payment()
        {
            this.processSession();

            Hashtable hash = Session["PRODUCTS"] as Hashtable;
            Hashtable cart = (Hashtable)hash.Clone();
            ProductModel productModel = new ProductModel();
            int count, stored;

            foreach (string key in hash.Keys)
            {
                count = productModel.count(key);
                stored = count - (int)hash[key];
                if (stored > -1)
                {
                    if (stored == productModel.payment(key, (int)hash[key]))
                    {
                        cart.Remove(key);
                    }
                }
            }

            if (cart.Count > 0)
            {
                Session["PRODUCTS"] = cart;
                Response.Redirect("/index/cart");
            }
            else
            {
                (Session["PRODUCTS"] as Hashtable).Clear();
                Response.Redirect("/");
            }
        }
    }
}
