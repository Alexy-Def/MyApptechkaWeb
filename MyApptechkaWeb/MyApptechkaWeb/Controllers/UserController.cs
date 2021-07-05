using AutoMapper;
using Microsoft.AspNetCore.Authentication;
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
using System.Threading;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private ISmsService _smsService;
        private IUserService _userService;
        private IPathHelperService _pathHelperService;

        public UserController(IUserRepository userRepository, IMapper mapper, ISmsService smsService,
            IUserService userService, IPathHelperService pathHelperService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _smsService = smsService;
            _userService = userService;
            _pathHelperService = pathHelperService;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            var model = new RegistrationViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (_userService.IsUserExist(model.Login))
                {
                    model.IsUserExist = true;
                }
                return View(model);
            }

            var isUserUniq = _userRepository.Get(model.Login) == null;
            if (isUserUniq)
            {
                var user = _mapper.Map<User>(model);
                user.Phone = _smsService.ConvertToDefaultPhoneNumber(user.Phone);
                _userRepository.Save(user);

                await HttpContext.SignInAsync(
                    _userService.GetPrincipal(user));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //ModelState.AddModelError(nameof(RegistrationViewModel.Login),
                //    "Такой пользователь уже существует");
                model.IsUserExist = true;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            //var returnUrl = Request.Query["ReturnUrl"];
            //model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userRepository.Get(model.Login);

            if (user == null || user.Password != model.Password)
            {
                if (user == null)
                {
                    model.IsUserNotExist = true;
                }
                else
                {
                    model.IsWrongPassword = true;
                }
                return View(model);
            }

            await HttpContext.SignInAsync(
                _userService.GetPrincipal(user));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public JsonResult IsUserExist(string login)
        {
            var isExistUserWithTheName =
                _userRepository.Get(login) != null;
            return Json(isExistUserWithTheName);
        }

        public JsonResult SendingSmsCode(string phone)
        {
            phone = _smsService.ConvertToDefaultPhoneNumber(phone);
            var generatedCode = _smsService.CreateCodeFromSms();

            _smsService.SendSMS(phone, $"[Test] Код подтверждения регистрации на сервисе MyApptechka: {generatedCode}");

            return Json(generatedCode);
        }
        
        [HttpGet]
        public IActionResult Profile()
        {
            var user = _userService.GetCurrent();


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAvatar(UpdateAvatarViewModel viewModel)
        {
            var user = _userService.GetCurrent();

            if (viewModel.Avatar != null)
            {
                var pathTo = _pathHelperService.GetPathToAvatarByUser(user.Id);
                using (var fileStream = new FileStream(pathTo, FileMode.OpenOrCreate))
                {
                    await viewModel.Avatar.CopyToAsync(fileStream);
                }
                user.AvatarUrl = _pathHelperService.GetAvatarUrlByUser(user.Id);

                _userRepository.Save(user);
            }

            return RedirectToAction("Profile");
        }
    }
}
