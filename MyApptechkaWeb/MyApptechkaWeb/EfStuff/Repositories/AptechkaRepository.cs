using MyApptechkaWeb.EfStuff.Model;
using MyApptechkaWeb.EfStuff.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.EfStuff.Repositories
{
    public class AptechkaRepository : BaseRepository<Aptechka>, IAptechkaRepository
    {
        public AptechkaRepository(MyApptechkaDbContext myApptechkaDbContext)
            : base(myApptechkaDbContext)
        {
        }


        //public User Get(string login)
        //{
        //    return _dbSet.SingleOrDefault(x =>
        //        x.Login.ToLower() == login.ToLower());
        //}
    }
}
