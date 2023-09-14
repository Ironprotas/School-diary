using JWT.Base;
using JWT.Models;

namespace JWT.Repositories.Interfaces
{
    public interface IScheduleRepository : IBaseRepository<Schedule>
    {

        public IEnumerable<Schedule> GetAll();

    }
}
