using JWT.Models;

namespace JWT.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel> 
    {
        TDbModel Get(Func<TDbModel, bool> predicate);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(int id);
        public TDbModel GetId(int id);
        public List<TDbModel> GetAll();


    }
}
