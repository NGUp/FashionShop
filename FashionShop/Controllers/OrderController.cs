using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;
using FashionShop.Models.Objects;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace FashionShop.Controllers
{
    public class OrderController : Controller
    {
        private OrderModel model = new OrderModel();

        //
        // GET: Admin/Order/
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["USER_PERMISSION"] == null || Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin/login", false);
            }

            return View();
        }

        [HttpPost]
        public ActionResult update()
        {
            if (Session["USER_PERMISSION"] == null || Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin/login", false);
            }

            if (Request.Params["customer_ID"] == null)
            {
                Response.Redirect("/admin/order");
            }

            if (Request.Params["purchase_ID"] == null)
            {
                Response.Redirect("/admin/order");
            }

            AccountModel accountModel = new AccountModel();
            Account account = accountModel.one(Request.Params["customer_ID"].ToString().Trim());

            ViewData["CUSTOMER_ID"] = account.ID;
            ViewData["CUSTOMER_NAME"] = account.Name;
            ViewData["PURCHASE_ID"] = Request.Params["purchase_ID"].ToString().Trim();

            return View();
        }

        [HttpGet]
        public JsonResult Total()
        {
            return Json(this.model.total(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(int param_0)
        {
            return Json(this.model.get(param_0), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getCartByPurchaseOrder(string param_0)
        {
            CartModel cartModel = new CartModel();
            return Json(cartModel.getCartByPurchaseOrder(param_0.Trim()), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void updateHandler()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("/admin/order");
            }

            if (Request.Params["cart"] == null)
            {
                Response.Redirect("/admin/order");
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

                cart[obj.Product.Id] = obj.Quantity;
            }

            string purchaseOrder = Request.Params["id"].ToString();
            CartModel cartModel = new CartModel();

            foreach (string key in cart.Keys)
            {
                if (Int32.Parse(cart[key].ToString()) > 0)
                {
                    cartModel.updateOrder(purchaseOrder, key, Int32.Parse(cart[key].ToString()));
                }
                else
                {
                    cartModel.deleteOrder(purchaseOrder, key);
                }
            }

            Response.Redirect("/admin/order");
        }
    }
}
