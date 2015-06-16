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
        private Security security = new Security();

        //
        // GET: /Manufacturer/
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["USER_PERMISSION"] == null || Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin/login", false);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            if (Session["USER_PERMISSION"] == null || Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin/login", false);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
            if (Session["USER_PERMISSION"] == null || Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin/login", false);
            }

            if (Request.Params["manufacturer_ID"] == null)
            {
                Response.Redirect("/admin/manufacturer", false);
            }

            ViewData["ID"] = Request.Params["manufacturer_ID"].Trim();
            ViewData["Name"] = this.model.getManufacturerName(Request.Params["manufacturer_ID"]);

            return View();
        }

        [HttpGet]
        public JsonResult getAll()
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.getAll(), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult getTopManufacturers()
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.getTopManufacturers(), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult Total()
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.total(), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult Get(int param_0)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.get(param_0), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult Search(int param_0, string param_1)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.search(security.decodeBase64(param_1), param_0), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult SearchResults(string param_0)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.totalResults(security.decodeBase64(param_0)), JsonRequestBehavior.AllowGet);
            }

            return null;
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
