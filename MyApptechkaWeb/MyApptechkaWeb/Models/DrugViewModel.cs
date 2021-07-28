using Microsoft.AspNetCore.Http;
using MyApptechkaWeb.EfStuff.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyApptechkaWeb.Models
{
    public class DrugViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Form { get; set; }
        public string Purpose { get; set; }
        public string ExpiryDate { get; set; }
        public string Residue { get; set; }
        public string AdditionalDescription { get; set; }
        public long AptechkaOwnerId { get; set; }
    }
}
