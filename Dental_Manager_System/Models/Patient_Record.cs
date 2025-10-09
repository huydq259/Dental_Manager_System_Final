using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dental_Manager.System.Models
{
    public class Patient_Record
    {
        [Key]
        public int RecordId { get; set; }
        [Required]
        public string MedicalHistory { get; set; }
        [Required]
        public string Allergies { get; set; }
        public string Notes { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        //RELATIONSHIP
        public long PatientId { get; set; }

        public long DoctorId { get; set; }
    }
}