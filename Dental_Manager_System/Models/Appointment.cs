using Dental_Manager.System.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dental_Manager.System.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }  // Scheduled, Completed, Cancelled
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }


        //RELATIONSHIPS
        public int PatientId { get; set; }


        public long DoctorId { get; set; }


        public long? ReceptionistId { get; set; }

    }
}