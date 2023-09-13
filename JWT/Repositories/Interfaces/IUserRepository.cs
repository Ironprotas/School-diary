using JWT.Models;
using Microsoft.AspNetCore.Identity;

namespace JWT.Repositories.Interfaces
{
    public interface IUserRepository
    { 
        Task <AppUser> GetClassIdFromUser (string userName);
        Task<AppUser> GetUserName(string userName);
        void AddParrent(AppUser? student, AppUser? parent);
        void DeleteParrent(AppUser? student);
        Task<List<AppUser>> GetAllUserInClass(int classId);

    }
}
