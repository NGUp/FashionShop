using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models.Objects;
using FashionShop.Models;

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
            ViewData["Birthday"] = account.Birthday;
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
    }
}
