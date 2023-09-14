using JWT.Models;

namespace JWT.Repositories.Interfaces
{
    public interface ISettingsLessonRepository : IBaseRepository<SettingsLesson>
    {

    Task<SettingsLesson> GetIdLessonTeach(int id);
    }
}

