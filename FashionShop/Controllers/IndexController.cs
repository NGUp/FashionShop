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
        public JsonResult isExisted(string param_0)
        {
            Analyze analyze = new Analyze();
            Security security = new Security();
            Hashtable hashTable = analyze.analyzeUserName(security.decodeBase64(param_0));
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
        public ActionResult Login()
        {
            return View();
        }
    }
}
