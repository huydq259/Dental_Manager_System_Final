using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dental_Manager.System.Models
{
    //Lịch hẹn
    public class Consulation
    {
        [Key]
        public int ConsulationId { get; set; }
        [Required]
        public string Dianoisis { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Quan hệ với Appointment
        [Required]
        public int AppointmentId { get; set; }

        // Quan hệ với Doctor (User)

        public long DoctorId { get; set; }
    }
}