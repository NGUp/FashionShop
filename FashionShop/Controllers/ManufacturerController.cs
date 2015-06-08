using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;
using FashionShop.Models.Objects;
using FashionShop.Misc;

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
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getTopManufacturers()
        {
            return Json(this.model.getTopManufacturers(), JsonRequestBehavior.AllowGet);
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
        public JsonResult Search(int param_0, string param_1)
        {
            Security security = new Security();

            return Json(this.model.search(security.decodeBase64(param_1), param_0), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchResults(string param_0)
        {
            Security security = new Security();

            return Json(this.model.totalResults(security.decodeBase64(param_0)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddHandler()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("/admin/manufacturer", false);
            }

            if (Request.Params["name"] == null)
            {
                Response.Redirect("/admin/manufacturer", false);
            }

            // Assign params into Manufacturer Model
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.Id = Request.Params["id"];
            manufacturer.Name = Request.Params["name"];

            // Execute update
            this.model.insert(manufacturer);
            Response.Redirect("/admin/manufacturer");
        }

        [HttpPost]
        public ActionResult Update()
        {
            if (Request.Params["manufacturer_ID"] == null)
            {
                Response.Redirect("/admin/manufacturer", false);
            }

            ViewData["ID"] = Request.Params["manufacturer_ID"].Trim();
            ViewData["Name"] = this.model.getManufacturerName(Request.Params["manufacturer_ID"]);

            return View();
        }

        [HttpPost]
        public void UpdateHandler()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("/admin/manufacturer", false);
            }

            if (Request.Params["name"] == null)
            {
                Response.Redirect("/admin/manufacturer", false);
            }

            // Assign params into Manufacturer Model
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.Id = Request.Params["id"];
            manufacturer.Name = Request.Params["name"];

            // Execute update
            this.model.update(manufacturer);
            Response.Redirect("/admin/manufacturer");
        }

        [HttpPost]
        public void Delete()
        {
            // Check param
            if (Request.Params["manufacturer"] == null)
            {
                Response.Redirect("/admin/manufacturer", false);
            }

            // Assign ID
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.Id = Request.Params["manufacturer_ID"];

            // Execute Delete
            this.model.delete(manufacturer);
            Response.Redirect("/admin/manufacturer");
        }
    }
}
