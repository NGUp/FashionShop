using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Admin/Login
        [HttpPost]
        public void LoginHandler()
        {
        }
    }
}
