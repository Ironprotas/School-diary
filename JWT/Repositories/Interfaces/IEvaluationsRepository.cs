using JWT.Models;

namespace JWT.Repositories.Interfaces
{
    public interface IEvaluationsRepository : IBaseRepository<Models.Evaluations>
    {
        Task<List<Models.Evaluations>> GetEvaluationsByLessonIds(List<int> lessonIds);

        Task<List<Models.Evaluations>> GetEvaluationsByLessonIdAndUserId(int lessonId, string userId);

        Task<List<int>> GetEvaluationsOneSubject(int lesssonId, string nameId);

        Task<List<int>> GetLessonObjectId(string userId);

        Task<List<Models.Evaluations>> GetEvaluationsForUser(string userId);


    }
}

