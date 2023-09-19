using JWT.Models;

namespace JWT.Repositories.Interfaces
{
    public interface IClassRepository : IBaseRepository<Models.Class>
    {
        Task<int> GetClassId(string name, int number);

        Task UpdateClass(int id, string name, int number);

        Task<Models.Class> GetClassWithStudents(string nameClass, int numberClass);

        Task<List<Models.Class>> GetAllClass();

        void AddStudentInClass(AppUser? user, int id);

    }
}

