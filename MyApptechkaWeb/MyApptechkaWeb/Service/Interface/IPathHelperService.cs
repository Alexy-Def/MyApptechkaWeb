using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Service.Interface
{
    public interface IPathHelperService
    {
        string GetPathToAvatarFolder();
        string GetPathToAptechkaPictureFolder();
        string GetPathToAvatarByUser(long userId);
        string GetPathToAptechkaPictureByAptechka(long aptechkaId);
        string GetAvatarUrlByUser(long userId);
        string GetAptechkaPictureUrlByAptechka(long aptechkaId);
    }
}
