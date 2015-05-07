using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;

namespace FashionShop.Controllers
{
    public class ProductController : Controller
    {
        private ProductModel model = new ProductModel();

        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult get(int param_0)
        {
            return Json(this.model.get(param_0), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Total()
        {
            return Json(this.model.total(), JsonRequestBehavior.AllowGet);
        }
    }
}
