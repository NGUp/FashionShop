using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using FashionShop.Models.Objects;
using Newtonsoft.Json;
using FashionShop.Misc;
using FashionShop.Models;
using System.Collections;

namespace FashionShop.Controllers
{
    public class IndexController : Controller
    {
        private AccountModel model = new AccountModel();

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

        //
        // GET: /Index/SignUp
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Manufacturers()
        {
            ManufacturerModel manufacturerModel = new ManufacturerModel();
            ViewData["manufacturers"] = manufacturerModel.getAll();
            return View();
        }

        [HttpGet]
        public JsonResult isExisted(string param_0)
        {
            Analyze analyze = new Analyze();
            Security security = new Security();
            Hashtable hashTable = analyze.analyzeUserName(security.decodeBase64(param_0.Replace("'", "''")));
            string userName = hashTable["UserName"].ToString();

            return Json(this.model.isExisted(userName), JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Index/SignUpHandler
        [HttpPost]
        public void SignUpHandler()
        {
            if (Request.Params["fullname"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["username"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["date"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["month"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["year"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["city"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["password"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["password"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["captcha"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            string captcha = Request.Params["captcha"];
            string url = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";

            const string secret = "6LdqAAcTAAAAAJksIEL3D7PqCRfqCauNYaQYpJIe";
            var client = new WebClient();
            var reply = client.DownloadString(string.Format(url, secret, captcha));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);


            if (captchaResponse.Success == true)
            {
                Account account = new Account();
                account.Name = Request.Params["fullname"];
                account.Username = Request.Params["username"];
                account.Password = Request.Params["password"];
                account.City = Request.Params["city"];

                int day = Int32.Parse(Request.Params["day"]);
                int month = Int32.Parse(Request.Params["month"]);
                int year = Int32.Parse(Request.Params["year"]);

                DateTime time = new DateTime(year, month, day);
                account.Birthday = time;

                Security security = new Security();
                account.Password = "38f923kd02" + security.encodeSHA1(account.Password) + "99e9k32o";
                account.Password = security.encodeMD5(account.Password);

                account.ID = security.generateID();

                this.model.insert(account);
            }
            else
            {
                Response.Redirect("/index/signup", false);
            }

            Response.Redirect("/index/login", false);
        }

        [HttpGet]
        public ActionResult Details(string param_0)
        {
            ProductModel model = new ProductModel();
            Product product = model.one(param_0.Replace("'", "''"));

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
            ViewData["product_Category"] = product.Category;

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Category(string param_0, int param_1)
        {
            ProductModel productModel = new ProductModel();
            CategoryModel categoryModel = new CategoryModel();

            ViewData["page"] = param_1;
            ViewData["total"] = productModel.getTotalPageByCategory(param_0);
            ViewData["category"] = categoryModel.getCategoryName(param_0);
            ViewData["products"] = productModel.getByCategory(param_0, param_1);
            return View();
        }

        [HttpGet]
        public ActionResult Manufacturer(string param_0, int param_1)
        {
            ProductModel productModel = new ProductModel();
            ManufacturerModel manufacturerModel = new ManufacturerModel();

            ViewData["page"] = param_1;
            ViewData["total"] = productModel.getTotalPageByManufacturer(param_0);
            ViewData["manufacturer"] = manufacturerModel.getManufacturerName(param_0);
            ViewData["products"] = productModel.getByManufacturer(param_0, param_1);
            return View();
        }

        [HttpPost]
        public void LoginHandler()
        {
            if (Request.Params["username"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["password"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            if (Request.Params["captcha"] == null)
            {
                Response.Redirect("/index/signup", false);
            }

            string captcha = Request.Params["captcha"];
            string url = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";

            const string secret = "6LdqAAcTAAAAAJksIEL3D7PqCRfqCauNYaQYpJIe";
            var client = new WebClient();
            var reply = client.DownloadString(string.Format(url, secret, captcha));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);


            if (captchaResponse.Success == true)
            {
                Account account = new Account();
                account.Username = Request.Params["username"];
                account.Password = Request.Params["password"];
                account.Permission = 0;

                Security security = new Security();
                account.Password = "38f923kd02" + security.encodeSHA1(account.Password) + "99e9k32o";
                account.Password = security.encodeMD5(account.Password);

                string ID = this.model.login(account);

                if (ID == null)
                {
                    Response.Redirect("/index/login", false);
                }

                Session.Add("USER_ID", ID);
                Session.Add("USER_PERMISSION", 0);
                Session.Add("USER_ACCOUNT", account.Username);
            }
            else
            {
                Response.Redirect("/index/login", false);
            }

            Response.Redirect("/", false);
        }

        [HttpPost]
        public void LogoutHandler()
        {
            if (Request.Params["token"] != null)
            {
                if (Request.Params["token"] == "7zv34gd8d2j")
                {
                    Session["USER_ID"] = null;
                    Session["USER_PERMISSION"] = null;
                    Session["USER_ACCOUNT"] = null;
                    Response.Redirect("/index/login", false);
                }
            }

            Response.Redirect("/", false);
        }
    }
}
