using System;
using System.ComponentModel.DataAnnotations;
using Dental_Manager.System.Models.Enums;

namespace Dental_Manager.System.Models
{
    public class User
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public RoleTitle RoleTitle { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
