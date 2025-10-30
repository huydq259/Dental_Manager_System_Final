using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dental_Manager_System.Models
{
    public class Diagnoisis
    {
        [Key]
        public string Name { get; set; }
    }
}