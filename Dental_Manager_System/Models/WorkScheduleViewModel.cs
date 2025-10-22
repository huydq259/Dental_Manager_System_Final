using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dental_Manager_System.Models
{
    public class WorkScheduleViewModel
    {
        public List<DoctorInfo> Doctors { get; set; }
        public List<AppointmentInfo> Appointments { get; set; }
        public List<SelectListItem> AppointmentDates { get; set; }
        public string ErrorMessage { get; set; }

        public class DoctorInfo
        {
            public long UserId { get; set; }
            public string FullName { get; set; }
        }

        public class AppointmentInfo
        {
            public int AppointmentId { get; set; }
            public string FullName { get; set; } // Tên bệnh nhân
            public long DoctorId { get; set; }
            public DateTime AppointmentDate { get; set; }
            public TimeSpan AppointmentTime { get; set; }
            public string Phone { get; set; }
            public string Dianoisis { get; set; } // Chuẩn đoán (kiểm tra chính tả nếu cần)
            public string DoctorName { get; set; } // Tên bác sĩ
            public DateTime? DateOfBirth { get; set; } // Thêm trường ngày sinh (tuỳ chọn)
        }
    }
}