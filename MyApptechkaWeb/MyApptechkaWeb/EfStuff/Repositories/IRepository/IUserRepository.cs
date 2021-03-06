using MyApptechkaWeb.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.EfStuff.Repositories.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User Get(string login);
    }
}
