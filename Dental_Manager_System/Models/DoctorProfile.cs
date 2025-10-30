using Dental_Manager.System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dental_Manager_System.Models
{
    public class DoctorProfile : User
    {
        [Required]
        [Display(Name = "Quản lý dịch vụ")]
        public string QuanLyDichVu { get; set; }

        [Required]
        [Display(Name = "Trình độ chuyên môn")]
        public string TrinhDoChuyenMon { get; set; }

        [Display(Name = "Hình đại diện")]
        public string AvatarPath { get; set; } 

        [Display(Name = "Tải lên hình đại diện")]
        public HttpPostedFileBase AvatarFile { get; set; }
    }
}