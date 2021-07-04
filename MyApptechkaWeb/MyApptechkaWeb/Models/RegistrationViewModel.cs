using System;
using System.ComponentModel.DataAnnotations;

namespace MyApptechkaWeb.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "test message")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "���� ����� �����")]
        [StringLength(13, ErrorMessage = "13 �������� ����")]
        [Phone]
        public string Phone { get; set; }
        public bool IsUserExist { get; set; }
    }
}
