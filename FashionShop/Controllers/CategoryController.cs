﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;
using FashionShop.Misc;
using FashionShop.Models.Objects;

namespace FashionShop.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryModel model = new CategoryModel();
        private Security security = new Security();
        
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

            if (Request.Params["category_ID"] == null)
            {
                Response.Redirect("/admin/category", false);
            }

            ViewData["ID"] = Request.Params["category_ID"].Trim();
            ViewData["Name"] = this.model.getCategoryName(Request.Params["category_ID"]);

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
        public JsonResult SearchResults(string param_0)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.totalResults(security.decodeBase64(param_0)), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult Search(int param_0, string param_1)
        {
            Security security = new Security();

            return Json(this.model.search(security.decodeBase64(param_1), param_0), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddHandler()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("/admin/category", false);
            }

            if (Request.Params["name"] == null)
            {
                Response.Redirect("/admin/category", false);
            }

            // Assign params into Category Model
            Category category = new Category();
            category.ID = Request.Params["id"];
            category.Name = Request.Params["name"];

            // Execute update
            this.model.insert(category);
            Response.Redirect("/admin/category");
        }

        [HttpPost]
        public void UpdateHandler()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("/admin/category", false);
            }

            if (Request.Params["name"] == null)
            {
                Response.Redirect("/admin/category", false);
            }

            // Assign params into Category Model
            Category category = new Category();
            category.ID = Request.Params["id"];
            category.Name = Request.Params["name"];

            // Execute update
            this.model.update(category);
            Response.Redirect("/admin/category");
        }

        [HttpPost]
        public void Delete()
        {
            // Check param
            if (Request.Params["category_ID"] == null)
            {
                Response.Redirect("/admin/category", false);
            }

            // Assign ID
            Category category = new Category();
            category.ID = Request.Params["category_ID"];

            // Execute Delete
            this.model.delete(category);
            Response.Redirect("/admin/category");
        }
    }
}
