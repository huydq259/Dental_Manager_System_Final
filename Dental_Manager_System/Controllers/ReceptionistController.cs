using Dental_Manager.System.Models;
using Dental_Manager.System.Models.Enums;
using Dental_Manager_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dental_Manager_System.Controllers

{
    public class ReceptionistController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Receptionist
        public ActionResult TrangChu()
        {
            return View();
        }

        public ActionResult ViewAppointments()
        {
            var appointments = db.Appointments
                .Where(a => a.AppointmentStatus == AppointmentStatus.SCHEDULED)
                .ToList();
            return View(appointments);
        }

        [HttpGet]
        public ActionResult CreateAppointment()
        {
            ViewBag.DoctorList = new SelectList(
                db.Users
                    .Where(u => u.RoleTitle == RoleTitle.DOCTOR)
                    .Select(u => new { u.UserId, u.FullName })
                    .ToList(),
                "UserId",
                "FullName"
            );

            ViewBag.DiagnosisList = new SelectList(
                db.Diagnoisis.Select(d => d.Name).Distinct().ToList()
            );

            return View(new Appointment());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.CreatedAt = DateTime.Now;
                appointment.AppointmentStatus = AppointmentStatus.SCHEDULED;

                // Optional: Set ReceptionistId từ current user
                // appointment.ReceptionistId = long.Parse(User.Identity.GetUserId()); // Nếu UserId là long

                db.Appointments.Add(appointment);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Tạo lịch hẹn thành công!";
                return RedirectToAction("ViewAppointments"); // Redirect về danh sách để hiển thị
            }

            // Populate lại ViewBag khi invalid
            ViewBag.DoctorList = new SelectList(
                db.Users
                    .Where(u => u.RoleTitle == RoleTitle.DOCTOR)
                    .Select(u => new { u.UserId, u.FullName })
                    .ToList(),
                "UserId",
                "FullName"
            );

            ViewBag.DiagnosisList = new SelectList(
                db.Diagnoisis.Select(d => d.Name).Distinct().ToList()
            );

            return View(appointment);
        }

        public ActionResult HistoryAppointment()
        {
            var appointments = db.Appointments
                .Where(a => a.AppointmentStatus == AppointmentStatus.COMPLETED || a.AppointmentStatus == AppointmentStatus.CANCELLED)
                .ToList();
            return View(appointments);
        }

        [HttpGet]
        public ActionResult UpdateAppointment(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("ViewAppointments");

            var appointment = db.Appointments.FirstOrDefault(p => p.AppointmentId == id);
            if (appointment == null)
                return HttpNotFound();

            // Populate ViewBag cho form update nếu cần (nếu view Update có dropdown)
            ViewBag.DoctorList = new SelectList(
                db.Users
                    .Where(u => u.RoleTitle == RoleTitle.DOCTOR)
                    .Select(u => new { u.UserId, u.FullName })
                    .ToList(),
                "UserId",
                "FullName",
                appointment.DoctorId // selected value
            );

            ViewBag.DiagnosisList = new SelectList(
                db.Diagnoisis.Select(d => d.Name).Distinct().ToList(),
                appointment.Dianoisis // selected
            );

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = db.Appointments.FirstOrDefault(p => p.AppointmentId == appointment.AppointmentId);
            if (existingAppointment == null)
                return HttpNotFound();

            existingAppointment.FullName = appointment.FullName;
            existingAppointment.Phone = appointment.Phone;
            existingAppointment.Dianoisis = appointment.Dianoisis;
            existingAppointment.AppointmentDate = appointment.AppointmentDate;
            existingAppointment.AppointmentTime = appointment.AppointmentTime;
            existingAppointment.DoctorId = appointment.DoctorId;


            db.SaveChanges();

            return RedirectToAction("ViewAppointments");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveAppointment(int id)
        {
            var appointment = db.Appointments.FirstOrDefault(p => p.AppointmentId == id);
            if (appointment != null)
            {
                appointment.AppointmentStatus = AppointmentStatus.COMPLETED;
                db.SaveChanges();
            }
            return RedirectToAction("HistoryAppointment");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppointment(int id)
        {
            var appointment = db.Appointments.FirstOrDefault(p => p.AppointmentId == id);
            if (appointment != null)
            {
                appointment.AppointmentStatus = AppointmentStatus.CANCELLED;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAppointments");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RestoreAppointment(int id)
        {
            var appointment = db.Appointments.FirstOrDefault(p => p.AppointmentId == id);
            if (appointment != null)
            {
                appointment.AppointmentStatus = AppointmentStatus.SCHEDULED;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAppointments");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}