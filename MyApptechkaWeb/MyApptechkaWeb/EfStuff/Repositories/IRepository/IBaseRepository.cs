using MyApptechkaWeb.EfStuff.Model;
using System.Collections.Generic;

namespace MyApptechkaWeb.EfStuff.Repositories
{
    public interface IBaseRepository<ModelType> where ModelType : BaseModel
    {
        public ModelType Get(long id);
        public List<ModelType> GetAll();
        public void Remove(long id);
        public void Remove(IEnumerable<long> id);
        public void Remove(ModelType model);
        public void Save(ModelType model);
    }
}