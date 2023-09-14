using JWT.Base;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace JWT.Repositories.Implementations
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel

    {
        private ApplicationDbContext Context { get; set; }

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }
        public TDbModel Create(TDbModel model)
        {
            Context.Set<TDbModel>().AddAsync(model);
            Context.SaveChanges();
            return model;
        }
        public void Delete(int id)
        {
            var toDelete = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
            Context.Set<TDbModel>().Remove(toDelete);
            Context.SaveChanges();
        }

        public  TDbModel Get(Func<TDbModel, bool> predicate)
        {
            return  Context.Set<TDbModel>().FirstOrDefault(predicate);
        }

        public TDbModel Update(TDbModel model)
        {
            var toUpdate = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }

        public TDbModel GetId(int Id)
        {
            return Context.Set<TDbModel>().FirstOrDefault(m => m.Id == Id);
        }

        public List<TDbModel> GetAll()
        {
            return Context.Set<TDbModel>().ToList();
        }


    }


 }

