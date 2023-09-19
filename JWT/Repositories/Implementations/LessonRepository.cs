using JWT.Base;
using JWT.Dto;
using JWT.Migrations;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace JWT.Repositories.Implementations
{
    public class LessonRepository: BaseRepository<Models.Lesson>, ILessonRepository
    {
        private ApplicationDbContext Context { get; set; }
    public LessonRepository(ApplicationDbContext context) : base(context)
    {
        Context = context;
    }

        public async Task<int> GetLessonId(string name)
        {
           return await Context.Lessons.Where(u => u.Name == name).Select(cl => cl.Id).FirstOrDefaultAsync();
        }

        public void DeleteTeacher(SettingsLesson? lessonDel)
        {
            lessonDel.TeacherId = null;
            Context.SaveChanges();
        }

        public void AddTeacher(SettingsLesson? lesson, AppUser? user)
        {
            lesson.Teacher = user; 
             Context.SaveChanges();
        }
    }
}
