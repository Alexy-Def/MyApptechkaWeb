using System;
using System.ComponentModel.DataAnnotations;

namespace MyApptechkaWeb.Models
{
    public class ProfileViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
    }
}
