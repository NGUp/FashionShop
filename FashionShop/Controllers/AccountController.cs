using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models.Objects;
using FashionShop.Models;
using System.Globalization;
using FashionShop.Misc;
using System.Collections;

namespace FashionShop.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Account Model
        /// </summary>
        private AccountModel model = new AccountModel();

        //
        // GET: /Admin/Account
        [HttpGet]
        public ActionResult Index()
        {
            // Check if is administrator
            if (Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin", false);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Update()
        {
            Account account = this.model.one(Request.Params["account_ID"]);
            ViewData["ID"] = account.ID;
            ViewData["Name"] = account.Name;
            ViewData["Username"] = account.Username;
            ViewData["City"] = account.City;
            ViewData["Birthday"] = account.Birthday.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ViewData["State"] = account.State;
            ViewData["Permission"] = account.Permission;
            return View();
        }

        //
        // GET: /Admin/Account/Total
        [HttpGet]
        public JsonResult Total()
        {
            return Json(this.model.total(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Account/SearchResults/{Keyword}
        [HttpGet]
        public JsonResult SearchResults(string param_0)
        {
            Analyze analyze = new Analyze();
            Security security = new Security();
            Hashtable hashTable = analyze.analyzeIdAndUser(security.decodeBase64(param_0));

            Account account = new Account();
            account.ID = hashTable["ID"].ToString();
            account.Username = hashTable["Username"].ToString();

            return Json(this.model.totalResults(account), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Account/Get/{page}
        [HttpGet]
        public JsonResult Get(int param_0)
        {
            return Json(this.model.get(param_0), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Account/Search/{Page}/{Keyword}
        [HttpGet]
        public JsonResult Search(int param_0, string param_1)
        {
            Analyze analyze = new Analyze();
            Security security = new Security();
            Hashtable hashTable = analyze.analyzeIdAndUser(security.decodeBase64(param_1));

            Account account = new Account();
            account.ID = hashTable["ID"].ToString();
            account.Username = hashTable["Username"].ToString();
            return Json(this.model.search(account, param_0), JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Admin/Account/UpdateHandler
        [HttpPost]
        public void UpdateHandler()
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect("/admin/account", false);
            }

            if (Request.Params["username"] == null)
            {
                Response.Redirect("/admin/account", false);
            }

            if (Request.Params["name"] == null)
            {
                Response.Redirect("/admin/account", false);
            }

            if (Request.Params["birthday"] == null)
            {
                Response.Redirect("/admin/account", false);
            }

            if (Request.Params["state"] == null)
            {
                Response.Redirect("/admin/account", false);
            }

            if (Request.Params["isAdmin"] == null)
            {
                Response.Redirect("/admin/account", false);
            }

            // Assign params into Account Model
            Account account = new Account();
            account.ID = Request.Params["id"];
            account.Username = Request.Params["username"];
            account.Name = Request.Params["name"];
            account.Birthday = DateTime.ParseExact(Request.Params["birthday"], "dd/MM/yyyy", null);
            account.State = Int32.Parse(Request.Params["state"]);
            account.Permission = Int32.Parse(Request.Params["isAdmin"]);
            account.City = Request.Params["city"];

            // Execute update
            this.model.update(account);
            Response.Redirect("/admin/account");
        }

        //
        // POST: /Admin/Account/Delete
        [HttpPost]
        public void Delete()
        {
            // Check param
            if (Request.Params["account_ID"] == null)
            {
                Response.Redirect("/admin/account", false);
            }

            // Assign ID
            Account account = new Account();
            account.ID = Request.Params["account_ID"];

            // Execute Delete
            this.model.delete(account);
            Response.Redirect("/admin/account");
        }
    }
}
