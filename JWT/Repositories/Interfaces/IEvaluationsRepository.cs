using JWT.Models;

namespace JWT.Repositories.Interfaces
{
    public interface IEvaluationsRepository : IBaseRepository<Evaluations>
    {
        Task<List<Evaluations>> GetEvaluationsByLessonIds(List<int> lessonIds);

        Task<List<Evaluations>> GetEvaluationsByLessonIdAndUserId(int lessonId, string userId);

        Task<List<int>> GetEvaluationsOneSubject(int lesssonId, string nameId);

        Task<List<int>> GetLessonObjectId(string userId);

        Task<List<Evaluations>> GetEvaluationsForUser(string userId);


    }
}

