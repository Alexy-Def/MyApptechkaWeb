using Microsoft.AspNetCore.Http;
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
    }
}
