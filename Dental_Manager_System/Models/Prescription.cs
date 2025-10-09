using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dental_Manager.System.Models
{
    //Đơn thuốc
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
       
        [Required]
        public int Quantity{ get; set; }
        public string DosageInstructions{ get; set; }


        // RELATIONSHIPS
        [Required]
        public int ConsulationId { get; set; }
        [Required]
        public int MedicineId { get; set; }

    }
}