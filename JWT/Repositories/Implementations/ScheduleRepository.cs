using JWT.Base;
using JWT.Models;
using JWT.Repositories.Interfaces;

namespace JWT.Repositories.Implementations
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository

    {
        private ApplicationDbContext Context { get; set; }
        public ScheduleRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<Schedule> GetAll()
        {

            return Context.Set<Schedule>().ToList(); 
            
        }
    }
}
