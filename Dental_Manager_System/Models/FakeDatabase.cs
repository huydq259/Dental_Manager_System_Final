using Dental_Manager.System.Models.Enums;
using Dental_Manager_System.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Dental_Manager_System.Models
{
    public class FakeDatabase
    {
        public static List<Appointment> Appointments { get; set; }

        static FakeDatabase()
        {
            Appointments = new List<Appointment>
            {
                new Appointment
                {
                    AppointmentId = 1,
                    FullName = "Nguyen Manh Thang",
                    Phone = "028500000",
                    Reason = "Bi sau rang",
                    AppointmentDate = DateTime.Now,
                    AppointmentTime = TimeSpan.FromHours(14), // Sử dụng FromHours để rõ ràng
                    AppointmentStatus = AppointmentStatus.SCHEDULED
                },
                new Appointment
                {
                    AppointmentId = 2,
                    FullName = "Doan Quang Huy",
                    Phone = "42000000",
                    Reason = "Bi sau rang",
                    AppointmentDate = DateTime.Now.AddDays(1),
                    AppointmentTime = TimeSpan.FromHours(15),
                    AppointmentStatus = AppointmentStatus.SCHEDULED
                },
                new Appointment
                {
                    AppointmentId = 3,
                    FullName = "Nguyen Van A",
                    Phone = "8900000",
                    Reason = "Bi sau rang",
                    AppointmentDate = DateTime.Now.AddDays(2),
                    AppointmentTime = TimeSpan.FromHours(16),
                    AppointmentStatus = AppointmentStatus.SCHEDULED
                }
            };
        }
    }
}