using Microsoft.EntityFrameworkCore;
using TalentPortalAPI.Data;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Repositories.Interfaces;

namespace TalentPortalAPI.Repositories
{
    public class RecruiterRepository : IRecruiterRepository
    {
        private readonly TalentPortalDbContext talentPortalDbContext;

        public RecruiterRepository(TalentPortalDbContext _talentPortalDbContext)
        {
            talentPortalDbContext = _talentPortalDbContext;
        }

        // Return a list of all recruiters
        public async Task<IEnumerable<Recruiter>> GetAllRecruiters()
        {
            var recruiters = await talentPortalDbContext.Recruiters.ToListAsync();
            if(recruiters.Count == 0)
            {
                return null;
            }
            else
            {
                return recruiters;
            }
        }

        // Add a recruiter (This will only be called in the jobrepository because only when a job is posted
        public async Task<Recruiter> AddRecruiter(int UserId, int JobId)
        {
            var doesexist = await talentPortalDbContext.Recruiters.FirstOrDefaultAsync(x => x.UserId == UserId && x.JobId == JobId);
            if (doesexist == null)
            {
                Recruiter recruiter = new Recruiter()
                {
                    UserId = UserId,
                    JobId = JobId
                };
                await talentPortalDbContext.Recruiters.AddAsync(recruiter);
                await talentPortalDbContext.SaveChangesAsync();

                return recruiter;
            }
            else
            {
                return null;
            }
        }

        public async Task<Recruiter> DeleteRecruiter(int UserId, int JobId)
        {
            var r = await talentPortalDbContext.Recruiters.FirstOrDefaultAsync(x => x.UserId == UserId && x.JobId == JobId);
            if (r != null)
            {
                talentPortalDbContext.Recruiters.Remove(r);
                await talentPortalDbContext.SaveChangesAsync();

                return r;
            }
            else
            {
                return null;
            }
        }
    }
}
