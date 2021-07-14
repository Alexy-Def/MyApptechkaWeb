using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApptechkaWeb.EfStuff.Model;
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
        private IMapper _mapper;

        public AptechkaController(IUserService userService, IAptechkaRepository aptechkaRepository, 
            IPathHelperService pathHelperService, IMapper mapper)
        {
            _userService = userService;
            _aptechkaRepository = aptechkaRepository;
            _pathHelperService = pathHelperService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Aptechka()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Aptechka(AddAptechkaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _userService.GetCurrent();
            var newAptechka = _mapper.Map<Aptechka>(viewModel);
            newAptechka.Owner = user;
            _aptechkaRepository.Save(newAptechka);

            if (viewModel.AptechkaPicture != null)
            {
                var pathTo = _pathHelperService.GetPathToAptechkaPictureByAptechka(newAptechka.Id);
                using (var fileStream = new FileStream(pathTo, FileMode.OpenOrCreate))
                {
                    await viewModel.AptechkaPicture.CopyToAsync(fileStream);
                }
                newAptechka.AptechkaPictureUrl = _pathHelperService.GetAptechkaPictureUrlByAptechka(newAptechka.Id);
            }
            _aptechkaRepository.Save(newAptechka);

            return View();
        }
    }
}
