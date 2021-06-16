using Microsoft.EntityFrameworkCore;
using MyApptechkaWeb.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApptechkaWeb.EfStuff.Repositories
{
    public abstract class BaseRepository<ModelType> 
        : IBaseRepository<ModelType> where ModelType : BaseModel
    {
        protected MyApptechkaDbContext _myApptechkaDbContext;
        protected DbSet<ModelType> _dbSet;

        public BaseRepository(MyApptechkaDbContext spaceDbContext)
        {
            _myApptechkaDbContext = spaceDbContext;
            _dbSet = _myApptechkaDbContext.Set<ModelType>();
        }

        public virtual List<ModelType> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual ModelType Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public virtual void Save(ModelType model)
        {
            if (model.Id > 0)
            {
                _dbSet.Update(model);
            }
            else
            {
                _dbSet.Add(model);
            }
            _myApptechkaDbContext.SaveChanges();
        }

        public virtual void Remove(long id)
        {
            var model = Get(id);
            Remove(model);
        }

        public virtual void Remove(ModelType model)
        {
            _myApptechkaDbContext.Remove(model);
            _myApptechkaDbContext.SaveChanges();
        }

        public virtual void Remove(IEnumerable<long> ids)
        {
            foreach (var userid in ids)
            {
                Remove(userid);
            }
        }
    }
}
