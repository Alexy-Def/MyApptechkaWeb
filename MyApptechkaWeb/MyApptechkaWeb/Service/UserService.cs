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
    public class UserService : IUserService
    {
        private IHttpContextAccessor _contextAccessor;
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IHttpContextAccessor contextAccessor)
        {
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
        }
        public ClaimsPrincipal GetPrincipal(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Id", user.Id.ToString()));
            claims.Add(new Claim(
                ClaimTypes.AuthenticationMethod,
                Startup.AuthMethod));
            var claimsIdentity = new ClaimsIdentity(claims, Startup.AuthMethod);
            var principal = new ClaimsPrincipal(claimsIdentity);
            return principal;
        }
        public User GetCurrent()
        {
            var idStr = _contextAccessor.HttpContext.User
                ?.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
            if (string.IsNullOrEmpty(idStr))
            {
                return null;
            }

            var id = long.Parse(idStr);
            return _userRepository.Get(id);
        }
        public bool IsUserExist(string login)
        {
            var isExistUserWithTheName =
                _userRepository.Get(login) != null;
            return isExistUserWithTheName;
        }
        public string GetAvatarUrl()
        {
            var userAvatar = GetCurrent()?.AvatarUrl;
            return !string.IsNullOrWhiteSpace(userAvatar)
                ? userAvatar
                : "/image/avatar/default-avatar.png";
        }
    }
}
