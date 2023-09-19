using JWT.Base;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace JWT.Repositories.Implementations
{
    public class EvaluationsRepository : BaseRepository<Models.Evaluations> , IEvaluationsRepository 
    {
        private ApplicationDbContext Context { get; set; }
        public EvaluationsRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
        public async Task<List<Models.Evaluations>> GetEvaluationsByLessonIds(List<int> lessonIds)
        {
            return await Context.Evaluations.Where(e => lessonIds.Contains(e.LessonId)).ToListAsync();
         
        }
        public async Task<List<Models.Evaluations>> GetEvaluationsByLessonIdAndUserId(int lessonId, string userId)
        {
            return await Context.Evaluations
                .Include(e => e.Lesson)
                .Where(e => e.LessonId == lessonId && e.UserId == userId)
                .ToListAsync();
        }

        public async Task <List<int>> GetEvaluationsOneSubject(int lesssonId, string nameId)
        {
           return await  Context.Evaluations.Where(x => x.LessonId == lesssonId && x.UserId == nameId).Select(x => x.Evaluaton).ToListAsync();
             
        }

        public async Task<List<int>> GetLessonObjectId(string userId)
        {
            return await Context.Evaluations.Where(x => x.UserId == userId).Select(x => x.LessonId).ToListAsync();
        }

        public async Task<List<Models.Evaluations>> GetEvaluationsForUser(string userId)
        {
            return await Context.Evaluations.Where(x => x.UserId == userId).ToListAsync();
        }

    }
}
