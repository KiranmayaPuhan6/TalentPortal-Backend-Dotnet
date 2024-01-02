using Microsoft.EntityFrameworkCore;
using TalentPortalAPI.Models.Domain;

namespace TalentPortalAPI.Data
{
    public class TalentPortalDbContext : DbContext
    {
        public TalentPortalDbContext( DbContextOptions options): base(options)
        {

        }

        public DbSet<Dept> Depts { get; set; }  

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobSkill> JobSkills { get; set; }

        public DbSet<Recruiter> Recruiters { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<JobApplicant> JobApplicants { get; set; }  

        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

    }
}
