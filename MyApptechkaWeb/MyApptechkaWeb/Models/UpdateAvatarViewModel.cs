using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Models
{
    public class UpdateAvatarViewModel
    {
        public IFormFile Avatar { get; set; }
    }
}
