using Dental_Manager.System.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dental_Manager.System.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId{ get; set; }
        [Required]
        public decimal Total{ get; set; }
        [Required]
        public DateTime PaidAt{ get; set; }
        [Required]
        public string PaymentMethod{ get; set; }
        [Required]
        public PaymentStatus PaymentStatus { get; set; }


        // RELATIONSHIPS
        [Required]
        public int AppointmentId { get; set; }

    }
}