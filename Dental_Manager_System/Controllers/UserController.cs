using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dental_Manager_System.Controllers

{
    public class UserController : Controller
    {

        public ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: User
        public ActionResult Trang_Chu()
        {
            //// Lấy email hoặc username đang đăng nhập
            //string email = User.Identity.Name;

            //// Nếu bạn có UserManager, có thể lấy thông tin chi tiết
            //var user = UserManager.FindByName(email);

            //ViewBag.UserEmail = email;
            //ViewBag.UserFullName = user?.FullName; // nếu model có thuộc tính FullName
            //ViewBag.IsLoggedIn = User.Identity.IsAuthenticated;
            return View();
        }

        public ActionResult UserLogin()
        {
            // Lấy email hoặc username đang đăng nhập
            string email = User.Identity.Name;

            // Nếu bạn có UserManager, có thể lấy thông tin chi tiết
            var user = UserManager.FindByName(email);

            ViewBag.UserEmail = email;
            ViewBag.UserFullName = user?.FullName; // nếu model có thuộc tính FullName
            ViewBag.IsLoggedIn = User.Identity.IsAuthenticated;
            return View();
        }

        public ActionResult UserLogout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("UserLogin", "User");
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Doctor()
        {
            return View();
        }
        public ActionResult Treatments()
        {
            return View();
        }

        [HttpGet]          
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult Pricing()
        {
            return View();
        }
    }
}