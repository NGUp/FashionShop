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

        //
        // GET: /Admin/Account/Get/{page}
        [HttpGet]
        public JsonResult Get(int page)
        {
            return Json(this.model.get(page), JsonRequestBehavior.AllowGet);
        }
    }
}
