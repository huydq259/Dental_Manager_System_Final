using Dental_Manager.System.Models.Enums;
using Dental_Manager_System.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Dental_Manager_System.Controllers
{
    public class ReceptionistController : Controller
    {
        // GET: Receptionist
        public ActionResult TrangChu()
        {
            return View();
        }

        public ActionResult ViewAppointments()
        {
            var appointments = FakeDatabase.Appointments
                .Where(a => a.AppointmentStatus == AppointmentStatus.SCHEDULED)
                .ToList();
            return View(appointments);
        }

        public ActionResult CreateAppointment()
        {
            return View();
        }

        public ActionResult HistoryAppointment()
        {
            var appointments = FakeDatabase.Appointments
                .Where(a => a.AppointmentStatus == AppointmentStatus.COMPLETED || a.AppointmentStatus == AppointmentStatus.CANCELLED)
                .ToList();
            return View(appointments);
        }

        [HttpGet]
        public ActionResult UpdateAppointment(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("ViewAppointments");

            var appointment = FakeDatabase.Appointments.FirstOrDefault(p => p.AppointmentId == id);
            if (appointment == null)
                return HttpNotFound();

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = FakeDatabase.Appointments.FirstOrDefault(p => p.AppointmentId == appointment.AppointmentId);
            if (existingAppointment == null)
                return HttpNotFound();

            existingAppointment.FullName = appointment.FullName;
            existingAppointment.Phone = appointment.Phone;
            existingAppointment.Reason = appointment.Reason;

            return RedirectToAction("HistoryAppointment"); // Redirect về History nếu chỉnh sửa từ đây
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveAppointment(int id)
        {
            var appointment = FakeDatabase.Appointments.FirstOrDefault(p => p.AppointmentId == id);
            if (appointment != null)
            {
                appointment.AppointmentStatus = AppointmentStatus.COMPLETED; // Chuyển sang COMPLETED
            }
            return RedirectToAction("HistoryAppointment"); // Chuyển sang HistoryAppointment
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAppointment(int id)
        {
            var appointment = FakeDatabase.Appointments.FirstOrDefault(p => p.AppointmentId == id);
            if (appointment != null)
            {
                appointment.AppointmentStatus = AppointmentStatus.CANCELLED; // Chuyển sang CANCELLED
            }
            return RedirectToAction("ViewAppointments"); // Ở lại ViewAppointments để reload
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RestoreAppointment(int id)
        {
            var appointment = FakeDatabase.Appointments.FirstOrDefault(p => p.AppointmentId == id);
            if (appointment != null)
            {
                appointment.AppointmentStatus = AppointmentStatus.SCHEDULED; // Chuyển về SCHEDULED
            }
            return RedirectToAction("ViewAppointments"); // Chuyển về ViewAppointments
        }
    }
}