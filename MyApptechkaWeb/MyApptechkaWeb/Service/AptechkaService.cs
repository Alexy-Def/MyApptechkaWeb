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
        private IAptechkaRepository _aptechkaRepository;
        public AptechkaService(IAptechkaRepository aptechkaRepository)
        {
            _aptechkaRepository = aptechkaRepository;
        }
        
        public string GetAptechkaPictureUrl(long idAptechka)
        {
            var aptechkaPicture = _aptechkaRepository.Get(idAptechka)?.AptechkaPictureUrl;
            return !string.IsNullOrWhiteSpace(aptechkaPicture)
                ? aptechkaPicture
                : "";
        }
    }
}
