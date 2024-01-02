using Microsoft.EntityFrameworkCore;
using TalentPortalAPI.Data;
using TalentPortalAPI.Models.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;
using TalentPortalAPI.Repositories.Interfaces;
using System.Text.Json.Serialization;

namespace TalentPortalAPI.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly TalentPortalDbContext talentPortalDbContext;
        private readonly IJobSkillRepository jobSkillRepository;
        private readonly IRecruiterRepository recruiterRepository;

        public JobRepository(TalentPortalDbContext _talentPortalDbContext, 
            IJobSkillRepository _jobSkillRepository, 
            IRecruiterRepository _recruiterRepository)
        {
            talentPortalDbContext = _talentPortalDbContext;
            jobSkillRepository = _jobSkillRepository;   
            recruiterRepository = _recruiterRepository; 
        }

        // Post a new job (doing this will makes changes to the Job, JobSkill and Recruiter Table)
        public async Task<Job> PostJob(Job job) // Works as intended
        {
            await talentPortalDbContext.Jobs.AddAsync(job);
            await talentPortalDbContext.SaveChangesAsync();
            
            return job;
        }

        // get list of all job in the portal
        public async Task<IEnumerable<Job>> ListAllJobs() // Works as intended
        {
            var jobs = await talentPortalDbContext.Jobs.ToListAsync();
            if (jobs.Count == 0)
            {
                return null;
            }
            else
            {
                return jobs;
            }
        }

        //update a job and it's skills
        public async Task<Job> UpdateJob(int JobId, Job job) // Works as intended
        {
            var oldJob = await talentPortalDbContext.Jobs.FirstOrDefaultAsync(x => x.JobId == JobId);

            if (oldJob != null) {
                oldJob.JobName = job.JobName;
                oldJob.Description = job.Description;
                oldJob.Experience = job.Experience;
                oldJob.Location = job.Location;
                await talentPortalDbContext.SaveChangesAsync();

                return job;
            }
            else
            {
                return null;
            }

            
        }

        public async Task<IEnumerable<Job>> ListOfJobsPostedByUser(int UserId) // Works as intended
        {
            var jobIds = await talentPortalDbContext.Recruiters.Where(x => x.UserId == UserId).ToListAsync();
            var jobs = new List<Job>();
            if (jobIds.Count != 0)
            {
                foreach (var j in jobIds)
                {
                    var job = await talentPortalDbContext.Jobs.SingleOrDefaultAsync(x => x.JobId == j.JobId);
                    if (job != null)
                    {
                        jobs.Add(job);
                    }
                }

                return jobs;
            }
            else
            {
                return null;
            }
        }

        public async Task<Job> DeleteJob(int JobId) // Works as intended
        {
            var job = await talentPortalDbContext.Jobs.FirstOrDefaultAsync(x => x.JobId == JobId);
            if (job != null)
            {
                // await recruiterRepository.DeleteRecruiter(UserId, JobId);
                talentPortalDbContext.Jobs.Remove(job);
                await talentPortalDbContext.SaveChangesAsync();

                return job;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Job>> GetJobsBySearchAsync(string searchText)
        {
            var jobs = new List<Job>();
            List<Job> query = new List<Job>();
            foreach (var text in searchText.Split(" "))
            {
                query = await talentPortalDbContext.Jobs.Where(x => x.JobName.Contains(text) || x.Description.Contains(text) || x.Location.Contains(text)).ToListAsync();
                
                if(query.Count != 0)
                {
                    foreach (var job in query)
                    {
                        jobs.Add(job);
                    }
                    
                }
            }

            if (jobs.Count == 0)
            {
                return null;
            }

            return jobs.Distinct().ToList();
        }
    }
}
