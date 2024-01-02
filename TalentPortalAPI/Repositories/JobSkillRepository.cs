using System.Security.Cryptography;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using TalentPortalAPI.Data;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Repositories.Interfaces;

namespace TalentPortalAPI.Repositories
{
    public class JobSkillRepository : IJobSkillRepository
    {
        private readonly TalentPortalDbContext talentPortalDbContext;
        private readonly ISkillRepository skillRepository;

        public JobSkillRepository(TalentPortalDbContext _talentPortalDbContext, ISkillRepository _skillRepository)
        {
            talentPortalDbContext = _talentPortalDbContext;
            skillRepository = _skillRepository; 
        }

        // get all jobs and their required skills
        public async Task<IEnumerable<JobSkill>> GetAllJobSkills() // Works as intended
        {
            var jobskills = await talentPortalDbContext.JobSkills.ToListAsync();
            if(jobskills.Count == 0)
            {
                return null;
            }
            else
            {
                return jobskills;
            }
        }

        // update a skill required by a job
        public async Task<JobSkill> PostOrUpdateJobSkill(int JobId, int SkillId) // Works as intended
        { 
            var checkskill = await talentPortalDbContext.JobSkills.FirstOrDefaultAsync(x => x.JobId == JobId && x.SkillId == SkillId);
            if (checkskill == null)
            {
                var jobskill = new JobSkill()
                {
                    JobId = JobId,
                    SkillId = SkillId
                };

                await talentPortalDbContext.JobSkills.AddAsync(jobskill);
                await talentPortalDbContext.SaveChangesAsync();

                return jobskill;    
            }
            else
            {
                return null;
            }
            
        }

        public async Task<IEnumerable<JobSkill>> DeleteAllJobSkills(int JobId)
        {
            var jobskills = await talentPortalDbContext.JobSkills.Where(x => x.JobId == JobId).ToListAsync();
            
            if (jobskills.Count != 0)
            {
                foreach(var js in jobskills)
                {
                    talentPortalDbContext.JobSkills.Remove(js);
                    await talentPortalDbContext.SaveChangesAsync(); 
                }

                return jobskills;
            }
            else
            {
                return null;
            }
        }

        public async Task<JobSkill> DeleteJobSkill(int JobId, int SkillId)
        {
            var jobskill = await talentPortalDbContext.JobSkills.FirstOrDefaultAsync(x => x.JobId == JobId && x.SkillId == SkillId);

            if (jobskill != null)
            {
                talentPortalDbContext.JobSkills.Remove(jobskill);
                await talentPortalDbContext.SaveChangesAsync();

                return jobskill;

            }
            else
            {
                return null;
            }
            
        }
    }
}
