using Dental_Manager.System.Models;
using Dental_Manager.System.Models.Enums;
using Dental_Manager_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Dental_Manager_System.Controllers
{
    [Authorize(Roles ="ADMIN")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: ADMIN
        public ActionResult Index()
        {
            return View();
        }
//------------------------------------ BÁC SĨ -------------------------------------//
        [HttpGet]
        public ActionResult DanhSachBacSi()
        {
            var newDoctor = new User();
            var doctors = db.Users.Where(u => u.RoleTitle == RoleTitle.DOCTOR).ToList();
            return View(new Tuple<User, List<User>>(newDoctor, doctors));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDoctor([Bind(Prefix = "Item1")] User doctor)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu nhập sai, load lại danh sách bác sĩ để hiển thị lại form
                var doctors = db.Users.Where(u => u.RoleTitle == RoleTitle.DOCTOR).ToList();
                return View("DanhSachBacSi", new Tuple<User, List<User>>(doctor, doctors));
            }

            doctor.RoleTitle = RoleTitle.DOCTOR;
            doctor.CreatedAt = DateTime.Now;
            doctor.UpdatedAt = DateTime.Now;

            db.Users.Add(doctor);
            db.SaveChanges();

            TempData["SuccessMessage"] = "Tạo bác sĩ thành công!";
            return RedirectToAction("DanhSachBacSi");
        }
        [HttpGet]
        public ActionResult EditDoctor(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var doctor = db.Users.Find(id);
            if (doctor == null)
                return HttpNotFound();

            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDoctor(User user)
        {
            user.RoleTitle = RoleTitle.DOCTOR;
            if (ModelState.IsValid)
            {
                if (user.DateOfBirth < new DateTime(1753, 1, 1))
                    user.DateOfBirth = null;

                if (user.CreatedAt < new DateTime(1753, 1, 1))
                    user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                var existingUser = db.Users.AsNoTracking().FirstOrDefault(u => u.UserId == user.UserId);
                if (existingUser != null)
                {
                    user.RoleTitle = existingUser.RoleTitle;
                    user.CreatedAt = existingUser.CreatedAt;
                    user.RoleTitle = existingUser.RoleTitle;
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Cập nhật thông tin bác sĩ thành công!";
                return RedirectToAction("DanhSachBacSi");
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult DeleteDoctor(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var doctor = db.Users.Find(id);
            if (doctor == null)
                return HttpNotFound();

            return View(doctor);
        }
        [HttpPost, ActionName("DeleteDoctor")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDoctorConfirmed(long id)
        {
            var doctor = db.Users.Find(id);
            if (doctor != null)
            {
                db.Users.Remove(doctor);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachBacSi");
        }



        



        //----------------------------------- NHÂN VIÊN ----------------------------------//
        [HttpGet]
        public ActionResult DanhSachNhanVIen()
        {
            var newReceptionist = new User();
            var receptionists = db.Users.Where(u => u.RoleTitle == RoleTitle.RECEPTIONIST).ToList();
            return View(new Tuple<User, List<User>>(newReceptionist, receptionists));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReceptionist([Bind(Prefix = "Item1")] User receptionist)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu nhập sai, load lại danh sách bác sĩ để hiển thị lại form
                var receptionists = db.Users.Where(u => u.RoleTitle == RoleTitle.RECEPTIONIST).ToList();
                return View("DanhSachNhanVien", new Tuple<User, List<User>>(receptionist, receptionists));
            }

            receptionist.RoleTitle = RoleTitle.RECEPTIONIST;
            receptionist.CreatedAt = DateTime.Now;
            receptionist.UpdatedAt = DateTime.Now;

            db.Users.Add(receptionist);
            db.SaveChanges();

            TempData["SuccessMessage"] = "Tạo nhân viên thành công!";
            return RedirectToAction("DanhSachBacSi");
        }
        [HttpGet]
        public ActionResult EditReceptionist(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var receptionist = db.Users.Find(id);
            if (receptionist == null)
                return HttpNotFound();

            return View(receptionist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReceptionist(User user)
        {
            user.RoleTitle = RoleTitle.RECEPTIONIST;
            if (ModelState.IsValid)
            {
                if (user.DateOfBirth < new DateTime(1753, 1, 1))
                    user.DateOfBirth = null;

                if (user.CreatedAt < new DateTime(1753, 1, 1))
                    user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                var existingUser = db.Users.AsNoTracking().FirstOrDefault(u => u.UserId == user.UserId);
                if (existingUser != null)
                {
                    user.RoleTitle = existingUser.RoleTitle;
                    user.CreatedAt = existingUser.CreatedAt;
                    user.RoleTitle = existingUser.RoleTitle;
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Cập nhật thông tin nhân viên thành công!";
                return RedirectToAction("DanhSachNhanVien");
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult DeleteReceptionist(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var receptionist = db.Users.Find(id);
            if (receptionist == null)
                return HttpNotFound();

            return View(receptionist);
        }
        [HttpPost, ActionName("DeleteReceptionist")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReceptionistConfirmed(long id)
        {
            var receptionist = db.Users.Find(id);
            if (receptionist != null)
            {
                db.Users.Remove(receptionist);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachNhanVien");
        }

        //---------------------------------- KẾT THÚC NHÂN VIÊN ---------------------------//



        //----------------------------------- KHÁCH HÀNG ----------------------------------//

        [HttpGet]
        public ActionResult DanhSachKhachHang()
        {
            var newPatient = new User();
            var patients = db.Users.Where(u => u.RoleTitle == RoleTitle.PATIENT).ToList();
            return View(new Tuple<User, List<User>>(newPatient, patients));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePatient([Bind(Prefix = "Item1")] User patient)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu nhập sai, load lại danh sách bác sĩ để hiển thị lại form
                var patients = db.Users.Where(u => u.RoleTitle == RoleTitle.PATIENT).ToList();
                return View("DanhSachNhanVien", new Tuple<User, List<User>>(patient, patients));
            }

            patient.RoleTitle = RoleTitle.PATIENT;
            patient.CreatedAt = DateTime.Now;
            patient.UpdatedAt = DateTime.Now;

            db.Users.Add(patient);
            db.SaveChanges();

            TempData["SuccessMessage"] = "Tạo khách hàng thành công!";
            return RedirectToAction("DanhSachBacSi");
        }
        [HttpGet]
        public ActionResult EditPatient(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var patient = db.Users.Find(id);
            if (patient == null)
                return HttpNotFound();

            return View(patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPatient(User user)
        {
            user.RoleTitle = RoleTitle.PATIENT;
            if (ModelState.IsValid)
            {
                if (user.DateOfBirth < new DateTime(1753, 1, 1))
                    user.DateOfBirth = null;

                if (user.CreatedAt < new DateTime(1753, 1, 1))
                    user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                var existingUser = db.Users.AsNoTracking().FirstOrDefault(u => u.UserId == user.UserId);
                if (existingUser != null)
                {
                    user.RoleTitle = existingUser.RoleTitle;
                    user.CreatedAt = existingUser.CreatedAt;
                    user.RoleTitle = existingUser.RoleTitle;
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Cập nhật thông tin nhân viên thành công!";
                return RedirectToAction("DanhSachNhanVien");
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult DeletePatient(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var patient = db.Users.Find(id);
            if (patient == null)
                return HttpNotFound();

            return View(patient);
        }
        [HttpPost, ActionName("DeletePatient")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePatientConfirmed(long id)
        {
            var patient = db.Users.Find(id);
            if (patient != null)
            {
                db.Users.Remove(patient);
                db.SaveChanges();
            }
            return RedirectToAction("DanhSachNhanVien");
        }

        //---------------------------------- KẾT THÚC KHACH HANG ---------------------------//


        public ActionResult QuanLyDichVu()
        {
            return View();
        }
        public ActionResult QuanLyThuoc()
        {
            return View();
        }
    }
}