using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dental_Manager_System.Controllers

{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Trang_Chu()
        {
            return View();
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
        public ActionResult UserLogin()
        {
            return View();
        }


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