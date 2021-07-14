using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApptechkaWeb.EfStuff.Repositories.IRepository;
using MyApptechkaWeb.Models;
using MyApptechkaWeb.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Controllers
{
    public class AptechkaController : Controller
    {
        private IUserService _userService;
        private IAptechkaRepository _aptechkaRepository;
        private IPathHelperService _pathHelperService;

        public AptechkaController(IUserService userService, IAptechkaRepository aptechkaRepository, IPathHelperService pathHelperService)
        {
            _userService = userService;
            _aptechkaRepository = aptechkaRepository;
            _pathHelperService = pathHelperService;
        }

        [HttpGet]
        public IActionResult Aptechka()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Aptechka(AddAptechkaViewModel viewModel)
        {
            var user = _userService.GetCurrent();
             //var newAptechka = 

            if (viewModel.AptechkaPicture != null)
            {
                var pathTo = _pathHelperService.GetPathToAvatarByUser(user.Id);
                using (var fileStream = new FileStream(pathTo, FileMode.OpenOrCreate))
                {
                    await viewModel.AptechkaPicture.CopyToAsync(fileStream);
                }
                //user.AvatarUrl = _pathHelperService.GetAvatarUrlByUser(user.Id);

                //_userRepository.Save(user);
            }

            return View();
        }
    }
}
