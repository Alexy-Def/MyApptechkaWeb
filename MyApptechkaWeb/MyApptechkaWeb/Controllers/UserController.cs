﻿using AutoMapper;
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

        public UserController(IUserRepository userRepository, IMapper mapper, ISmsService smsService,
            IUserService userService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _smsService = smsService;
            _userService = userService;
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
                ModelState.AddModelError(nameof(RegistrationViewModel.Login),
                    "Такой пользователь уже существует");
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

        public JsonResult IsUserExist(string name)
        {
            var isExistUserWithTheName =
                _userRepository.Get(name) != null;
            return Json(isExistUserWithTheName);
        }

        public JsonResult SendingSmsCode(string phone)
        {
            phone = _smsService.ConvertToDefaultPhoneNumber(phone);
            var generatedCode = _smsService.CreateCodeFromSms();

            _smsService.SendSMS(phone, $"[Test] Код подтверждения регистрации на сервисе MyApptechka: {generatedCode}");

            return Json(generatedCode);
        }
    }
}
