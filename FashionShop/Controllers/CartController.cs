using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace FashionShop.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public void refresh()
        {
            (Session["PRODUCTS"] as Hashtable).Clear();
            Response.Redirect("/", false);
        }
    }
}
