using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using TalentPortalAPI.Data;
using TalentPortalAPI.Models.Domain;
using TalentPortalAPI.Repositories.Interfaces;

namespace TalentPortalAPI.Repositories
{
    public class JobApplicantRepository : IJobApplicantRepository
    {
        private readonly TalentPortalDbContext talentPortalDbContext;
        
        public JobApplicantRepository(TalentPortalDbContext _talentPortalDbContext)
        {
            this.talentPortalDbContext = _talentPortalDbContext;
        }

        public async Task<IEnumerable<JobApplicant>> ListAllJobApplicants()
        {
            var jobapplicants = await talentPortalDbContext.JobApplicants.ToListAsync();
            if(jobapplicants.Count == 0)
            {
                return null;
            }
            else
            {
                return jobapplicants;
            }
        }

        // Post a job application
        public async Task<JobApplicant> PostJobApplication(JobApplicant jobApplicant)
        {
            await talentPortalDbContext.JobApplicants.AddAsync(jobApplicant);
            await talentPortalDbContext.SaveChangesAsync();
            return jobApplicant;
        }

        // Update Job Application Status for a userid-jobid combo
        public async Task<JobApplicant> UpdateJobApplicationStatus(int UserId, int JobId, string newApplicationStatus)
        {
            var jobApplicant = await talentPortalDbContext.JobApplicants.SingleOrDefaultAsync(x => x.UserId == UserId && x.JobId == JobId);
            if (jobApplicant == null)
            {
                return null;
            }
            else
            {
                jobApplicant.ApplicationStatus = newApplicationStatus;
                await talentPortalDbContext.SaveChangesAsync();
                return jobApplicant;
            }
        }

        // Find application status of a particular job posted by a particular user
        public async Task<JobApplicant> FindApplicationStatus(int UserId, int JobId)
        {
            var jobapplicant = await talentPortalDbContext.JobApplicants.FirstOrDefaultAsync(a => a.UserId == UserId && a.JobId == JobId);
            if (jobapplicant != null)
            {
                return jobapplicant;
            }
            else
            {
                return null;
            }
        }

        // Returns all jobs applied by a user
        public async Task<IEnumerable<Job>> ListApplicantJobs(int UserId)
        {
            var jobapplicant = await talentPortalDbContext.JobApplicants.Where(x => x.UserId == UserId).ToListAsync();
            var jobs = new List<Job>();
            if (jobapplicant.Count != 0)
            {
                foreach (var applicant in jobapplicant)
                {
                    var joblistofapplicant = await talentPortalDbContext.Jobs.FirstOrDefaultAsync(x => x.JobId == applicant.JobId);
                    if (joblistofapplicant != null)
                    {
                        jobs.Add(joblistofapplicant);
                    }
                }
                return jobs;
            }
            else
            {
                return null;
            }
        }

        // Update the job application (update the resume basically)
        // (Every job does not require the same resume)
        //public async Task<JobApplicant> UpdateJobApplication(int UserId, int JobId, Byte[] UserResume)
        //{
        //    var jobapplication = await talentPortalDbContext.JobApplicants.Where(x => x.UserId == UserId && x.JobId == JobId).SingleAsync();
        //    if (jobapplication != null)
        //    {
        //        jobapplication.UserResume = UserResume;
        //        await talentPortalDbContext.SaveChangesAsync();
        //    }

        //    return (jobapplication);
        //}

        public async Task<JobApplicant> DeleteJobApplicant(int UserId, int JobId)
        {
            var ja = await talentPortalDbContext.JobApplicants.FirstOrDefaultAsync(x => x.UserId == UserId && x.JobId == JobId);
            if (ja != null)
            {
                talentPortalDbContext.JobApplicants.Remove(ja);
                await talentPortalDbContext.SaveChangesAsync();

                return ja;
            }
            else
            {
                return null;
            }
        }

    }
}
