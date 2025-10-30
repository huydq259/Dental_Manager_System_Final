using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dental_Manager.System.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string DosageForm{ get; set; }
        [Required]
        public decimal Price{ get; set; }
    }
}