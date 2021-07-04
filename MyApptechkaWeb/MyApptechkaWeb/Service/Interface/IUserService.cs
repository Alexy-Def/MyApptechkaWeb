using MyApptechkaWeb.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Service.Interface
{
    public interface IUserService
    {
        ClaimsPrincipal GetPrincipal(User user);
        User GetCurrent();
        bool IsUserExist(string login);
        string GetAvatarUrl();
    }
}
