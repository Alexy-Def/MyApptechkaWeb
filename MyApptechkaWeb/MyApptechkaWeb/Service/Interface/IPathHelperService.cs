using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Service.Interface
{
    public interface IPathHelperService
    {
        string GetPathToAvatarFolder();
        string GetPathToAvatarByUser(long userId);
        string GetAvatarUrlByUser(long userId);
    }
}
