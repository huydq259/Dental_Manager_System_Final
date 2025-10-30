using Dental_Manager.System.Models.Enums;
using Dental_Manager_System.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dental_Manager_System.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ViewAppointmentForDoctor()
        {
            ViewBag.DoctorList = new SelectList(
      db.Users
          .Where(u => u.RoleTitle == RoleTitle.DOCTOR)
          .Select(u => new SelectListItem
          {
              Value = u.UserId.ToString(),
              Text = u.FullName
          })
          .ToList(),
      "Value",
      "Text"
  );
            var appointments = db.Appointments
                .Where(a => a.AppointmentStatus == AppointmentStatus.COMPLETED)
                .ToList();
            return View(appointments);

        }

        public ActionResult WorkSchedule(string selectedDate = null)
        {
            var model = new WorkScheduleViewModel();

            // Lấy danh sách bác sĩ với RoleTitle = RoleTitle.DOCTOR
            var doctors = db.Users
                .Where(u => u.RoleTitle == RoleTitle.DOCTOR)
                .Select(u => new WorkScheduleViewModel.DoctorInfo
                {
                    UserId = u.UserId,
                    FullName = u.FullName ?? "Không xác định"
                })
                .ToList();

            // Debug: Kiểm tra dữ liệu bác sĩ
            System.Diagnostics.Debug.WriteLine($"Số lượng bác sĩ: {doctors.Count}");
            foreach (var doctor in doctors)
            {
                System.Diagnostics.Debug.WriteLine($"Doctor - UserId: {doctor.UserId}, FullName: {doctor.FullName}");
            }

            model.Doctors = doctors;

            // Kiểm tra nếu không có bác sĩ
            if (!doctors.Any())
            {
                model.ErrorMessage = "Không tìm thấy bác sĩ nào trong cơ sở dữ liệu với RoleTitle = RoleTitle.DOCTOR. Vui lòng kiểm tra lại.";
            }

            // Xử lý ngày được chọn, mặc định là hôm nay
            DateTime filterDate = DateTime.Today;
            if (!string.IsNullOrEmpty(selectedDate) && DateTime.TryParse(selectedDate, out DateTime parsedDate))
            {
                filterDate = parsedDate.Date;
            }

            // Lấy danh sách ngày có cuộc hẹn đã phê duyệt
            var appointmentDates = db.Appointments
                .Where(a => a.AppointmentStatus == AppointmentStatus.COMPLETED)
                .Select(a => DbFunctions.TruncateTime(a.AppointmentDate))
                .Distinct()
                .OrderBy(d => d)
                .ToList();
            model.AppointmentDates = appointmentDates.Select(d => new SelectListItem
            {
                Value = d.Value.ToString("yyyy-MM-dd"),
                Text = d.Value.ToString("dd/MM/yyyy")
            }).ToList();

            // Lấy danh sách cuộc hẹn đã phê duyệt cho ngày được chọn
            var appointments = db.Appointments
                .Where(a => a.AppointmentStatus == AppointmentStatus.COMPLETED &&
                            DbFunctions.TruncateTime(a.AppointmentDate) == filterDate)
                .Select(a => new WorkScheduleViewModel.AppointmentInfo
                {
                    AppointmentId = a.AppointmentId,
                    FullName = a.FullName ?? "Không xác định",
                    DoctorId = a.DoctorId,
                    AppointmentDate = a.AppointmentDate,
                    AppointmentTime = a.AppointmentTime,
                    Phone = a.Phone ?? "N/A",
                    Dianoisis = a.Dianoisis ?? "Chưa có chuẩn đoán",
                    DoctorName = db.Users.FirstOrDefault(u => u.UserId == a.DoctorId).FullName ?? "Không xác định"
                })
                .ToList();
            // Debug: Kiểm tra dữ liệu cuộc hẹn
            System.Diagnostics.Debug.WriteLine($"Số lượng cuộc hẹn: {appointments.Count}");
            foreach (var appt in appointments)
            {
                System.Diagnostics.Debug.WriteLine($"Appointment - Id: {appt.AppointmentId}, Patient: {appt.FullName}, Doctor: {appt.DoctorName}, Date: {appt.AppointmentDate}, Time: {appt.AppointmentTime}");
            }
            model.Appointments = appointments;

            return View(model);
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