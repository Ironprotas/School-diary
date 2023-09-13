using JWT.Base;
using JWT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;

namespace JWT.Base
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<ScheduleLesson> ScheduleLessons { get; set; }
        public DbSet<SettingsLesson> SettingsLessons { get; set; }
        public DbSet<Evaluations> Evaluations { get; set; }
        public object ScheduleLesson { get; internal set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().HasOne(c => c.Class).WithOne(c => c.ClassTeacher).HasForeignKey<AppUser>(au => au.WorkClassId);
        }

    }
}




