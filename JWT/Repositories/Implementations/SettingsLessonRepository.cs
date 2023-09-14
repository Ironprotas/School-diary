using JWT.Base;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JWT.Repositories.Implementations
{
    public class SettingsLessonRepository : BaseRepository<SettingsLesson> , ISettingsLessonRepository
    {
        private ApplicationDbContext Context { get; set; }
        public SettingsLessonRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }

        public async Task<SettingsLesson> GetIdLessonTeach(int id)
        {
            return  await Context.SettingsLessons.Include(t => t.Teacher).FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
