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

            if (viewModel.Id != 0)
            {
                return RedirectToAction("Aptechka", new { Id = viewModel.Id });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Aptechka(long id)
        {
            var user = _userService.GetCurrent();
            var openedAptechka = user.Aptechkas.SingleOrDefault(x => x.Id == id);

            var viewModel = _mapper.Map<AddAptechkaViewModel>(openedAptechka);
            //var finalDrugModel = new List<DrugViewModel>();
            viewModel.Drugs = _drugRepository
                .GetAll()
                .Where(x => x.AptechkaOwner.Id == id)
                .Select(x => _mapper.Map<DrugViewModel>(x))
                .ToList();
            viewModel.CountDrugs = viewModel.Drugs.Count();

            //finalDrugModel = _mapper.Map<DrugViewModel>(drugs);

            //drugs.Select(x => _mapper.Map<DrugViewModel>(x));

            //finalDrugModel
            //    .Where(x => x.AptechkaOwner.Id == id)
            //    .Select(_mapper.Map<DrugViewModel>(x))
            //finalDrugModel.AptechkaOwner = openedAptechka;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddDrug(DrugViewModel viewModel)
        {
            var aptechka = _aptechkaRepository.Get(viewModel.AptechkaOwnerId);
            //viewModel.AptechkaOwner = aptechka;
            //var aptechkaName = viewModel.AptechkaOwner.Name;

            var dbModel = _mapper.Map<Drug>(viewModel);
            dbModel.AptechkaOwner = aptechka;
            _drugRepository.Save(dbModel);
            

            return RedirectToAction("Aptechka", new { id = viewModel.AptechkaOwnerId });
        }

        [HttpGet]
        public IActionResult Drug(long id)
        {
            var drugDbModel = _drugRepository.Get(id);
            var viewModel = _mapper.Map<DrugViewModel>(drugDbModel);

            return View(viewModel);
        }

        public IActionResult DeleteDrug(long idDrug, long idAptechka)
        {
            _drugRepository.Remove(idDrug);

            return RedirectToAction("Aptechka", new { id = idAptechka });
        }

        public IActionResult DelAptPic(long id)
        {
            var aptechka = _aptechkaRepository.Get(id);
            aptechka.AptechkaPictureUrl = null;
            _aptechkaRepository.Save(aptechka);

            return RedirectToAction("Aptechka", new { Id = id });
        }

        public IActionResult DelAptechka(long id)
        {
            var aptechka = _aptechkaRepository.Get(id);
            
            var drugs = aptechka.Drugs;
            foreach (var drug in drugs.ToList())
            {
                _drugRepository.Remove(drug);
            }

            _aptechkaRepository.Remove(aptechka);
            

            return RedirectToAction("Aptechkas");
        }
    }
}
