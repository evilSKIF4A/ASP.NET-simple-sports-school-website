using Microsoft.EntityFrameworkCore;
using Sport_school_Fortune.Models;

namespace Sport_school_Fortune.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Sportsman> Sportsmans { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Activity> Activitys { get; set; }
        public DbSet<Member> Members { get; set; }
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
