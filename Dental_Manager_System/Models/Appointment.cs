using Dental_Manager.System.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dental_Manager_System.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public DateTime? AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; } = AppointmentStatus.SCHEDULED; // Sử dụng enum từ Enums
        public string Reason { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // RELATIONSHIPS
        public int PatientId { get; set; }
        public long DoctorId { get; set; }
        public long? ReceptionistId { get; set; }
    }
}