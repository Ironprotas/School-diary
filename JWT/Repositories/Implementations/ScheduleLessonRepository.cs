using DocumentFormat.OpenXml.EMMA;
using JWT.Base;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JWT.Repositories.Implementations
{
    public class ScheduleLessonRepository : BaseRepository<ScheduleLesson>, IScheduleLessonRepository
    {
        private ApplicationDbContext Context { get; set; }
        public ScheduleLessonRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
        public IQueryable<ScheduleLesson> SheduleLessonGet(int? id)
        {
            return Context.ScheduleLessons
                .Include(c => c.SettingsLesson)
                .Include(c => c.Schedule).Include(c => c.Lesson)
                .Where(c => c.Schedule.ClassId == id);
        }

        public async Task<List<ScheduleLesson>> ScheduleLessonEvanuationList(int? id)
        {
            return await Context.ScheduleLessons.Include(x => x.Lesson)
                .Include(x => x.Schedule)
                .Where(x => x.Schedule.ClassId == id)
                .ToListAsync();
        }

        public async Task<ScheduleLesson> GetLessonIfon(int id)
        {
            return await Context.ScheduleLessons.Include(x => x.Schedule).Include(x => x.SettingsLesson).FirstOrDefaultAsync(x => x.SettingsLessonId == id);
            
        }

        public async Task<ScheduleLesson> GetDateLesson(int? id)
        {
            return await Context.ScheduleLessons.
                Include(x => x.Schedule).FirstOrDefaultAsync(x => x.LessonId == id);
        }

        public async Task<ScheduleLesson> GetEvanuationFromNameLesson(string nameLesson)
        {
            return await  Context.ScheduleLessons.Include(x => x.Lesson)
                .Include(x => x.SettingsLesson).FirstOrDefaultAsync(x => x.Lesson.Name == nameLesson);
        }

        public async Task<ScheduleLesson> GetLesson(int id)
        {
            return await  Context.ScheduleLessons.Include(x => x.SettingsLesson).
                Include(x => x.Schedule).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<ScheduleLesson> GetInfoLessonForUpdate(int id)
        {
            return await  Context.ScheduleLessons.Include(c => c.SettingsLesson).FirstOrDefaultAsync(l => l.SettingsLesson.Id == id);

        }

        public async Task<List <ScheduleLesson>> GetAllLessons()
        {
            return await Context.ScheduleLessons.Include(x => x.Lesson).Include(x => x.SettingsLesson).ToListAsync();
        }
    }
}
