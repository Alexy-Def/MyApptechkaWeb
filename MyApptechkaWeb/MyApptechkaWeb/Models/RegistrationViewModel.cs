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

        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "���� ����� �����")]
        [Phone]
        public string Phone { get; set; }
    }
}
