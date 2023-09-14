using JWT.Base;
using JWT.Models;
using JWT.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JWT.Repositories.Implementations
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        private ApplicationDbContext Context { get; set; }
        public ClassRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }

        public async Task<int> GetClassId(string name, int number)
        {
            return  await Context.Classes.Where(cl => cl.Name == name && cl.Number == number).Select(cl => cl.Id).FirstOrDefaultAsync();
        }

        public async Task UpdateClass(int id, string name, int number)
        {
            var cl = await Context.Classes.FirstOrDefaultAsync(x => x.Id == id);
            if (cl != null)
            {
                cl.Name = name;
                cl.Number = number;
                Context.Classes.Update(cl);
                await Context.SaveChangesAsync();

            }

        }
        public async Task<Class> GetClassWithStudents(string nameClass, int numberClass)
        {
            return await Context.Classes
                .Where(cl => cl.Name == nameClass && cl.Number == numberClass)
                .Include(c => c.Student)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Class>> GetAllClass()
        {
            return await Context.Classes.ToListAsync();
        }

        public async void AddStudentInClass(AppUser? user, int id)
        {
           user.ClassId = id;
           Context.SaveChangesAsync();
        }
    }
}
