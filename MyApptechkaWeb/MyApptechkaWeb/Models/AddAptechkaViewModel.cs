using Microsoft.AspNetCore.Http;
using MyApptechkaWeb.EfStuff.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyApptechkaWeb.Models
{
    public class AddAptechkaViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Color { get; set; }
        public string AdditionalDescription { get; set; }
        public IFormFile AptechkaPicture { get; set; }
        public User Owner { get; set; }
    }
}
