using JWT.Base;
using JWT.Models;
using JWT.Repositories.Interfaces;

namespace JWT.Repositories.Implementations
{
    public class HomeWorkRepository : BaseRepository<HomeWork>, IHomeWorkRepository
    {
        private ApplicationDbContext Context { get; set; }
        public HomeWorkRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
