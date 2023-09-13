using JWT.Models;

namespace JWT.Repositories.Interfaces
{
    public interface IScheduleLessonRepository : IBaseRepository<ScheduleLesson>
    {
        IQueryable<ScheduleLesson> SheduleLessonGet(int? id);

        Task<List<ScheduleLesson>> ScheduleLessonEvanuationList(int? id);
        Task<ScheduleLesson> GetDateLesson(int? id);

        Task<ScheduleLesson> GetLessonIfon(int id);

        Task<ScheduleLesson> GetEvanuationFromNameLesson(string nameLesson);

        Task<ScheduleLesson> GetLesson(int id);

        Task<ScheduleLesson> GetInfoLessonForUpdate(int id);

        Task<List<ScheduleLesson>> GetAllLessons();

    }
}
