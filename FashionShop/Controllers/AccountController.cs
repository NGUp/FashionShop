using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Account
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

        [HttpGet]
        public JsonResult Get()
        {
            String[] data = {"ABC", "SADSA"};
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
