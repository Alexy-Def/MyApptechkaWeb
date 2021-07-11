using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApptechkaWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Controllers
{
    public class AptechkaController : Controller
    {
        

        public AptechkaController()
        {
            
        }

        [HttpGet]
        public IActionResult Aptechka()
        {
            return View();
        }

    }
}
