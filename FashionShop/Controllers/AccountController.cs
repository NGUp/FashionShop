using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models.Objects;
using FashionShop.Models;
using System.Globalization;
using FashionShop.Misc;

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
        // GET: /Admin/Account/Get/{page}
        [HttpGet]
        public JsonResult Get(int page)
        {
            return Json(this.model.get(page), JsonRequestBehavior.AllowGet);
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

            if (Request.Params["password"] == null)
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
            account.Password = Request.Params["password"];
            account.State = Int32.Parse(Request.Params["state"]);
            account.Permission = Int32.Parse(Request.Params["isAdmin"]);
            account.City = Request.Params["city"];

            // Encode password
            Security security = new Security();
            account.Password = "38f923kd02" + security.encodeSHA1(account.Password) + "99e9k32o";
            account.Password = security.encodeMD5(account.Password);

            // Execute update
            this.model.update(account);
            Response.Redirect("/admin/account");
        }
    }
}
