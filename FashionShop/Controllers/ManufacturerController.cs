using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;

namespace FashionShop.Controllers
{
    public class ManufacturerController : Controller
    {
        private ManufacturerModel model = new ManufacturerModel();

        //
        // GET: /Manufacturer/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getTopManufacturers()
        {
            return Json(this.model.getTopManufacturers(), JsonRequestBehavior.AllowGet);
        }
    }
}
