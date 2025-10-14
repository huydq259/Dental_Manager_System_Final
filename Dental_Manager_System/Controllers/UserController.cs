using Dental_Manager.System.Models;
using Dental_Manager.System.Models.Enums;
using Dental_Manager_System.Models;
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
        private readonly ApplicationDbContext db = new ApplicationDbContext();


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
            ViewBag.DiagnosisList = new SelectList(
            db.Diagnoisis.Select(d => d.Name).Distinct().ToList()
            );

            ViewBag.DoctorList = new SelectList(
            db.Users
            .Where(u => u.RoleTitle == RoleTitle.DOCTOR)
            .Select(u => new { u.UserId, u.FullName })
            .ToList(),
            "UserId",    
            "FullName"   
    );

            return View();
        }
        public ActionResult History()
        {
            return View();

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Appointment(Appointment appointment)
        { 
            if (ModelState.IsValid)
            {
                
                appointment.CreatedAt = DateTime.Now;
                appointment.AppointmentStatus = AppointmentStatus.SCHEDULED;

                db.Appointments.Add(appointment);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Đặt lịch thành công!";
                return RedirectToAction("Trang_Chu", "User");
            }


            // Nếu ModelState invalid thì load lại danh sách
            //ViewBag.DiagnosisList = new SelectList(db.Diagnoisis.Select(d => d.Name).Distinct().ToList());
            //ViewBag.DoctorList = new SelectList(db.Users.Select(u => new { u.UserId, u.FullName }).ToList(), "FullName");
            return View(appointment);
        }
    }
}
