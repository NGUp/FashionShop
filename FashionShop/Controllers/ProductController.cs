using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;
using FashionShop.Models.Objects;
using FashionShop.Misc;
using System.Collections;
using System.IO;

namespace FashionShop.Controllers
{
    public class ProductController : Controller
    {
        private ProductModel model = new ProductModel();
        private Security security = new Security();

        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
            Product product = this.model.one(Request.Params["product_ID"].Replace("'", "''"));

            ViewData["product_ID"] = product.Id;
            ViewData["product_Name"] = product.Name;
            ViewData["product_Manufacturer"] = product.Manufacturer.Trim();
            ViewData["product_Price"] = Normalization.standardizePrice(product.Price);
            ViewData["product_Origin"] = product.Origin;
            ViewData["product_Views"] = product.Views;
            ViewData["product_Sales"] = product.Sales;
            ViewData["product_Image"] = product.Image;
            ViewData["product_State"] = product.State;
            ViewData["product_Sex"] = product.Sex;

            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
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
        public JsonResult Total()
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.total(), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult OrderProduct(string param_0)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                string ID = param_0.Replace("'", "''");
                Product product = this.model.one(ID);

                if (product == null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }

                Hashtable cart = (Session["PRODUCTS"] as Hashtable);
                cart[ID] = 1;
                Session["PRODUCTS"] = cart;
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult SearchResults(string param_0)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                Analyze analyze = new Analyze();
                Hashtable hashTable = analyze.analyzeProductIdAndName(security.decodeBase64(param_0.Replace("'", "''")));

                Product product = new Product();
                product.Id = hashTable["ProductID"].ToString();
                product.Name = hashTable["ProductName"].ToString();

                return Json(this.model.totalResults(product), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult getByCategory(string param_0, int param_1)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.getByCategory(param_0.Replace("'", "''").Trim(), param_1), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult getByManufacturer(string param_0, int param_1)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.getByManufacturer(param_0.Replace("'", "''").Trim(), param_1), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult Search(int param_0, string param_1)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                Analyze analyze = new Analyze();
                Hashtable hashTable = analyze.analyzeProductIdAndName(security.decodeBase64(param_1.Replace("'", "''")));

                Product product = new Product();
                product.Id = hashTable["ProductID"].ToString();
                product.Name = hashTable["ProductName"].ToString();
                return Json(this.model.search(product, param_0), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult GetNews()
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.getNews(), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult GetSales()
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.getSales(), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpGet]
        public JsonResult RelativeProducts(string param_0)
        {
            if (security.checkToken(Request.Headers["Authorization"].ToString()))
            {
                return Json(this.model.getRelativeProducts(param_0.Replace("'", "''")), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        [HttpPost]
        public void AddHandler()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["name"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["manufacturer"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["price"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["origin"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["sex"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            Product product = new Product();
            product.Id = Request.Params["id"];
            product.Name = Request.Params["name"];
            product.Manufacturer = Request.Params["manufacturer"];
            product.Price = Int32.Parse(Request.Params["price"]);
            product.Origin = Request.Params["origin"];
            product.Sex = Int32.Parse(Request.Params["sex"]);

            if (Request.Files["image"].FileName != "")
            {
                product.Image = product.Id + ".jpg";
            }

            if (this.model.insert(product) == true)
            {
                if (Request.Files["image"].FileName != "")
                {
                    HttpPostedFileBase file = Request.Files["image"];
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/img/products"), Path.GetFileName(product.Id) + ".jpg");
                    file.SaveAs(filePath);
                }
            }

            Response.Redirect("/admin/product");
        }

        [HttpPost]
        public void UpdateHandler()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["name"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["manufacturer"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["price"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["origin"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            if (Request.Params["sex"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            Product product = new Product();
            product.Id = Request.Params["id"];
            product.Name = Request.Params["name"];
            product.Manufacturer = Request.Params["manufacturer"];
            product.Price = Int32.Parse(Request.Params["price"]);
            product.Origin = Request.Params["origin"];
            product.Sex = Int32.Parse(Request.Params["sex"]);

            if (Request.Files["image"].FileName != "")
            {
                product.Image = product.Id + ".jpg";
            }

            if (this.model.update(product) == true)
            {
                if (Request.Files["image"].FileName != "")
                {
                    HttpPostedFileBase file = Request.Files["image"];
                    string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/img/products"), Path.GetFileName(product.Id) + ".jpg");
                    System.IO.File.Delete(filePath);
                    file.SaveAs(filePath);
                }
            }

            Response.Redirect("/admin/product");
        }

        [HttpPost]
        public void DeleteHandler()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("/admin/product", false);
            }

            Product product = new Product();
            product.Id = Request.Params["id"];

            this.model.delete(product);
            Response.Redirect("/admin/product");
        }
    }
}
