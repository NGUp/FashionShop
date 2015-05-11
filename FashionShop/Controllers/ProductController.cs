using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;
using FashionShop.Models.Objects;
using FashionShop.Misc;
using System.Collections;

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

        [HttpPost]
        public ActionResult Update()
        {
            Product product = this.model.one(Request.Params["product_ID"]);
            ViewData["product_ID"] = product.Id;
            ViewData["product_Name"] = product.Name;
            ViewData["product_Manufacturer"] = product.Manufacturer;
            ViewData["product_Price"] = product.Price;
            ViewData["product_Origin"] = product.Origin;
            ViewData["product_Views"] = product.Views;
            ViewData["product_Sales"] = product.Sales;
            ViewData["product_Image"] = product.Image;
            ViewData["product_State"] = product.State;
            ViewData["product_Sex"] = product.Sex;

            return View();
        }

        [HttpGet]
        public JsonResult SearchResults(string param_0)
        {
            Analyze analyze = new Analyze();
            Security security = new Security();
            Hashtable hashTable = analyze.analyzeProductIdAndName(security.decodeBase64(param_0));

            Product product = new Product();
            product.Id = hashTable["ProductID"].ToString();
            product.Name = hashTable["ProductName"].ToString();

            return Json(this.model.totalResults(product), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Search(int param_0, string param_1)
        {
            Analyze analyze = new Analyze();
            Security security = new Security();
            Hashtable hashTable = analyze.analyzeProductIdAndName(security.decodeBase64(param_1));

            Product product = new Product();
            product.Id = hashTable["ProductID"].ToString();
            product.Name = hashTable["ProductName"].ToString();
            return Json(this.model.search(product, param_0), JsonRequestBehavior.AllowGet);
        }
    }
}
