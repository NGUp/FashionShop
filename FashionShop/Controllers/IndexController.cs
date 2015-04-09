using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Index/About
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}
