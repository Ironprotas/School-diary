using JWT.Models;

namespace JWT.Repositories.Interfaces
{
    public interface IClassRepository : IBaseRepository<Class>
    {
        Task<int> GetClassId(string name, int number);

        Task UpdateClass(int id, string name, int number);

        Task<Class> GetClassWithStudents(string nameClass, int numberClass);

        Task<List<Class>> GetAllClass();

        void AddStudentInClass(AppUser? user, int id);

    }
}

