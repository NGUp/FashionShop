using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;

namespace FashionShop.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryModel model = new CategoryModel();

        [HttpGet]
        public JsonResult getAll()
        {
            return Json(this.model.getAll(), JsonRequestBehavior.AllowGet);
        }
    }
}
