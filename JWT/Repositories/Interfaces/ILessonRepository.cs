using JWT.Models;

namespace JWT.Repositories.Interfaces
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<int> GetLessonId(string name);

        void DeleteTeacher(SettingsLesson? lessonDel);

        void AddTeacher(SettingsLesson? lesson, AppUser? user);
    }
}
