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
        private IDrugRepository _drugRepository;
        private IPathHelperService _pathHelperService;
        private IMapper _mapper;

        public AptechkaController(IUserService userService, IAptechkaRepository aptechkaRepository,
            IDrugRepository drugRepository, IPathHelperService pathHelperService, IMapper mapper)
        {
            _userService = userService;
            _aptechkaRepository = aptechkaRepository;
            _drugRepository = drugRepository;
            _pathHelperService = pathHelperService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Aptechkas()
        {
            //var user = _userService.GetCurrent();
            //var aptechkas = user.Aptechkas.SingleOrDefault();

            //var viewModel = _mapper.Map<AddAptechkaViewModel>(aptechkas);

            return View(/*viewModel*/);
        }

        [HttpPost]
        public async Task<IActionResult> Aptechkas(AddAptechkaViewModel viewModel)
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

        [HttpGet]
        public IActionResult Aptechka(long id)
        {
            var user = _userService.GetCurrent();
            var openedAptechka = user.Aptechkas.SingleOrDefault(x => x.Id == id);

            var viewModel = _mapper.Map<AddAptechkaViewModel>(openedAptechka);
            var drugmodel = new DrugViewModel();
            drugmodel.AptechkaOwner = openedAptechka;
            return View(drugmodel);
        }

        [HttpPost]
        public IActionResult AddDrug(DrugViewModel viewModel)
        {
            var user = _userService.GetCurrent();
            var aptechka = _aptechkaRepository.Get(viewModel.AptechkaOwner.Id);
            viewModel.AptechkaOwner = aptechka;
            var aptechkaName = viewModel.AptechkaOwner.Name;

            var dbModel = _mapper.Map<Drug>(viewModel);
            _drugRepository.Save(dbModel);
            

            return RedirectToAction("Aptechka/id=4");
        }
    }
}
