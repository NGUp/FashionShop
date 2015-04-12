using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;
using FashionShop.Models.Objects;
using FashionShop.Misc;

namespace FashionShop.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult Index()
        {
            // Check if is administrator
            if (Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin/login", false);
            }

            return View();
        }

        //
        // GET: /Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            if (!(Session["USER_ID"] == null && Session["USER_PERMISSION"] == null))
            {
                if (Convert.ToInt32(Session["USER_PERMISSION"]) == 1)
                {
                    Response.Redirect("/admin");    // Administrator
                }
                else
                {
                    Response.Redirect("/"); // Anonymous/Guest/Registerd User
                }
            }

            return View();
        }

        // Product
        // GET: /Admin/Product
        [HttpGet]
        public ActionResult Product()
        {
            // Check if is administrator
            if (Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin", false);
            }

            return View();
        }

        // Product type
        // GET: /Admin/Type
        [HttpGet]
        public ActionResult Type()
        {
            // Check if is administrator
            if (Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin", false);
            }

            return View();
        }

        // Manufacturer
        // GET: /Admin/Manufacturer
        [HttpGet]
        public ActionResult Manufacturer()
        {
            // Check if is administrator
            if (Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin", false);
            }

            return View();
        }

        // Account
        // GET: /Admin/Account
        [HttpGet]
        public ActionResult Account()
        {
            // Check if is administrator
            if (Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin", false);
            }

            return View();
        }

        // PurchaseOrder
        // GET: /Admin/Order
        [HttpGet]
        public ActionResult Order()
        {
            // Check if is administrator
            if (Convert.ToInt32(Session["USER_PERMISSION"]) != 1)
            {
                Response.Redirect("/admin", false);
            }

            return View();
        }

        //
        // POST: /Admin/Login
        [HttpPost]
        public void LoginHandler()
        {
            if (Request.Params["username"] != null && Request.Params["password"] != null)
            {
                // Create new user model
                User user = new User();
                user.Username = Request.Params["username"];
                user.Password = Request.Params["password"];
                user.Permission = 1;
                
                // Encode password
                Security security = new Security();
                user.Password = "38f923kd02" + security.encodeSHA1(user.Password) + "99e9k32o";
                user.Password = security.encodeMD5(user.Password);

                // Login
                UserModel model = new UserModel();
                string ID = model.login(user);

                // Check If is administrator
                if (ID == null)
                {
                    Response.Redirect("/admin/login");
                }
                else
                {
                    Session["USER_ID"] = ID;
                    Session["USER_PERMISSION"] = 1;
                    Response.Redirect("/admin", false);
                }
            }
        }

        //
        // POST: /Admin/Logout
        [HttpPost]
        public void LogoutHandler()
        {
            if (Request.Params["token"] != null)
            {
                if (Request.Params["token"] == "7zv34gd8d2j")
                {
                    Session["USER_ID"] = null;
                    Session["USER_PERMISSION"] = null;
                    Response.Redirect("/admin/login", false);
                }
            }

            Response.Redirect("/admin", false);
        }
    }
}
