using Microsoft.AspNetCore.Hosting;
using MyApptechkaWeb.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Service
{
    public class PathHelperService : IPathHelperService
    {
        public const string AvatarUrlFolder = "/image/avatar/";
        public const string AptechkaPictureUrlFolder = "/image/aptechkaPicture/";
        private IWebHostEnvironment _webHostEnvironment;

        public PathHelperService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetPathToAvatarFolder()
        {
            var webPath = _webHostEnvironment.WebRootPath;
            var path = Path.Combine(webPath, "image", "avatar");
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public string GetPathToAptechkaPictureFolder()
        {
            var webPath = _webHostEnvironment.WebRootPath;
            var path = Path.Combine(webPath, "image", "aptechkaPicture");
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public string GetPathToAvatarByUser(long userId)
        {
            var avatarFolderPath = GetPathToAvatarFolder();

            return Path.Combine(avatarFolderPath, $"{userId}.jpg");
        }

        public string GetPathToAptechkaPictureByAptechka(long aptechkaId)
        {
            var avatarFolderPath = GetPathToAptechkaPictureFolder();

            return Path.Combine(avatarFolderPath, $"{aptechkaId}.jpg");
        }

        public string GetAvatarUrlByUser(long userId)
        {
            return $"{AvatarUrlFolder}{userId}.jpg";
        }

        public string GetAptechkaPictureUrlByAptechka(long aptechkaId)
        {
            return $"{AptechkaPictureUrlFolder}{aptechkaId}.jpg";
        }
    }
}
