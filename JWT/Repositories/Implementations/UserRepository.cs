using JWT.Base;
using JWT.Dto;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JWT.Repositories.Implementations
{
    public class UserRepository :  IdentityUser, IUserRepository
    {
        private ApplicationDbContext Context { get; set; }
        public UserRepository(ApplicationDbContext context) 
        {
            Context = context;
        }

        public async Task<AppUser> GetUserName (string UserName)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.UserName == UserName);

        }

        public async void DeleteParrent(AppUser? student)
        {
            student.ParentId = null;
            Context.SaveChangesAsync();
        }

        public void AddParrent(AppUser? student, AppUser? parent)
        {
            student.ParentId = parent.Id;
            Context.SaveChanges();
        }

        public async Task<AppUser> GetClassIdFromUser(string userName)
        {

            return await Context.Users.Include(u => u.Class).FirstOrDefaultAsync(u => u.UserName == userName);

        }

        public async Task<List<AppUser>> GetAllUserInClass(int classId)
        {
            return await Context.Users.Where(u => u.ClassId == classId).ToListAsync();
        }
    }
}
