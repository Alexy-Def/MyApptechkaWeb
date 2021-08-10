using Microsoft.AspNetCore.Http;
using MyApptechkaWeb.EfStuff.Model;
using MyApptechkaWeb.EfStuff.Repositories.IRepository;
using MyApptechkaWeb.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Service
{
    public class AptechkaService : IAptechkaService
    {
        private IUserService _userService;
        public AptechkaService(IUserService userService)
        {
            _userService = userService;
        }
        
        public string GetAptechkaPictureUrl()
        {
            var userAvatar = _userService.GetCurrent()?.AvatarUrl;
            return !string.IsNullOrWhiteSpace(userAvatar)
                ? userAvatar
                : "/image/avatar/default-avatar.png";
        }
    }
}
